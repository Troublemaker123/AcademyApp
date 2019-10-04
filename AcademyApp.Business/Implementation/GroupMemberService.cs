using System;
using System.Collections.Generic;
using System.Linq;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;

namespace AcademyApp.Business.Implementation
{
  public class GroupMemberService : IGroupMemberService
    {
        private readonly IRepository<GroupMembers> _groupMembersRepository;
        public GroupMemberService(IRepository<GroupMembers> groupMembersRepository)
        {
            _groupMembersRepository = groupMembersRepository;
        }

        public void Create(GroupMembersViewModel groupMember)
        {
            if(groupMember == null)
                throw new Exception("student not found");

            var domain = groupMember.ToDomain();
            _groupMembersRepository.Create(domain);
        }

        public void Delete(int groupMemberId, int academyProgramId)
        {
            var group = _groupMembersRepository.FindByMultipleId(groupMemberId, academyProgramId);
            if (group == null)
                throw new Exception("group is null");
            _groupMembersRepository.Delete(group);
        }

        public GroupMembersViewModel FindById(int apId)
        {
            var groupMember = _groupMembersRepository.FindById(apId);
            if (groupMember == null)
                    throw new Exception("Group member not found");
            return groupMember.ToModel();
        }

        public IEnumerable<GroupMembersViewModel> GetAll(int academyProgramId)
        {
            return _groupMembersRepository.GetAll().Where(groupMember => groupMember.ApId == academyProgramId)
                 .Select(groupMember => groupMember.ToModel()).ToList();
        }

       
    }
}
