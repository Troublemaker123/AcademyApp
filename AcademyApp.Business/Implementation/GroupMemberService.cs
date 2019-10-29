using AcademyApp.Business.Enums;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IRepository<GroupMembers> _groupMembersRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Student> _studentRepository;

        public GroupMemberService(
            IRepository<GroupMembers> groupMembersRepository,
            IRepository<Mentor> mentorRepository,
            IRepository<Student> studentRepository)
        {
            _groupMembersRepository = groupMembersRepository;
            _studentRepository = studentRepository;
            _mentorRepository = mentorRepository;
        }

        public void Create(List<GroupMembersViewModel> members)
        {
            if (!members.Any()) return;
            foreach (var member in members)
            {
                var domain = member.ToDomain();
                _groupMembersRepository.Create(domain);
            }
        }

        public void Delete(int groupMemberId, int academyProgramId)
        {
            var group = _groupMembersRepository.GetAll().FirstOrDefault(gm => gm.Id == groupMemberId && gm.ApId == academyProgramId);
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

        public IEnumerable<GroupMembersViewModel> GetAll(int groupId, int academyProgramId)
        {
            var members = new List<GroupMembersViewModel>();

            var groupMembers = _groupMembersRepository.GetAll().Where(gm => gm.GroupId == groupId && gm.ApId == academyProgramId);

            var mentors =
                from gm in groupMembers
                join m in _mentorRepository.GetAll() on gm.UserId equals m.ID

                where gm.UserType == (int)UserType.Mentor

                select new GroupMembersViewModel
                {
                    Id = gm.Id,
                    GroupId = gm.GroupId,
                    UserId = gm.UserId,
                    AcademyProgramId = gm.ApId,
                    FullName = m.Name + " " + m.LastName,
                    UserType = (UserType)gm.UserType
                };

            var students =
              from gm in groupMembers
              join s in _studentRepository.GetAll() on gm.UserId equals s.ID

              where gm.UserType == (int)UserType.Student

              select new GroupMembersViewModel
              {
                  Id = gm.Id,
                  GroupId = gm.GroupId,
                  UserId = gm.UserId,
                  AcademyProgramId = gm.ApId,
                  FullName = s.Name + " " + s.LastName,
                  UserType = (UserType)gm.UserType
              };

            members.AddRange(students);
            members.AddRange(mentors);

            return members;
        }

        public IEnumerable<GroupMembersViewModel> GetMentorsAndStudents(int groupId, int academyProgramId)
        {
            var members = new List<GroupMembersViewModel>();

            var groupMembers = _groupMembersRepository.GetAll().Where(gm => gm.ApId == academyProgramId);

            // mentors
            var mentorsByGroup = groupMembers.Where(gm => gm.GroupId == groupId && gm.UserType == (int)UserType.Mentor);
            var mentors = _mentorRepository.GetAll().Where(m => m.ApId == academyProgramId && !mentorsByGroup.Any(gm => gm.UserId == m.ID)).Select(x => x.ToMentorViewModel()).ToList();

            // students
            var studentGroupMembers = groupMembers.Where(gm => gm.UserType == (int)UserType.Student);
            var students = _studentRepository.GetAll().Where(s => s.ApId == academyProgramId && !studentGroupMembers.Any(sgm => sgm.UserId == s.ID)).Select(x => x.ToGroupMemberModel()).ToList();

            members.AddRange(students);
            members.AddRange(mentors);

            return members;
        }
    }
}
