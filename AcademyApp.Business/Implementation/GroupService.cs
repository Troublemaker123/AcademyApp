using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<GroupMembers> _groupMembersRepository;


        public GroupService(IRepository<Group> groupRepository,
            IRepository<GroupMembers> groupMembersRepository)
        {
            _groupRepository = groupRepository;
            _groupMembersRepository = groupMembersRepository;
        }


        public void Create(GroupViewModel model)
        {
            if(model == null)
                throw new ApplicationException("group is null");

            var domain = model.ToDomain();
            _groupRepository.Create(domain);
        }

        public void Delete(int groupId, int academyProgramId)
        {
            var groupMembers = _groupMembersRepository.GetAll().Where(g => g.GroupId == groupId && g.ApId == academyProgramId).ToList();
            foreach (var member in groupMembers)
            {
                _groupMembersRepository.Delete(member);
            }
            

            var group = _groupRepository.GetAll().FirstOrDefault(g => g.ID == groupId && g.ApId == academyProgramId);

            _groupRepository.Delete(group);
        }

        public GroupViewModel FindById(int groupId)
        {
            var group = _groupRepository.FindById(groupId);
            if (group == null)
                throw new Exception("GroupId not found");

            return group.ToModel();
        }


        public IEnumerable<GroupViewModel> GetAll(int academyProgramId)
        {
            return _groupRepository.GetAll().Where(model => model.ApId == academyProgramId)
                .Select(model => model.ToModel()).ToList();
        }

        public void Update(GroupViewModel model)
        {
            var group = _groupRepository.FindByMultipleId(model.ID,model.AcademyProgramId);
            if (group == null)
                throw new Exception();

            group.ID = group.ID;
            group.Title = group.Title;

            _groupRepository.Update(group);
        }
    }
}
