using AcademyApp.Business.Enums;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
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
        private readonly IRepository<GroupStudents> _groupStudentsRepository;
        private readonly IRepository<GroupMentors> _groupMentorsRepository;
        private readonly IRepository<Mentor> _mentorRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Group> _groupRepository;
        private readonly IRepository<AcademyProgram> _academyProgramrepository;
        private readonly IRepository<Academy> _academyRepository;

        public GroupMemberService(
            IRepository<GroupStudents> groupStudentsRepository,
            IRepository<Mentor> mentorRepository,
            IRepository<Student> studentRepository,
            IRepository<GroupMentors> groupMentorsRepository,
            IRepository<Group> groupRepository,
            IRepository<AcademyProgram> academyProgramrepository,
            IRepository<Academy> academyRepository)
        {
            _groupStudentsRepository = groupStudentsRepository;
            _studentRepository = studentRepository;
            _mentorRepository = mentorRepository;
            _groupMentorsRepository = groupMentorsRepository;
            _groupRepository = groupRepository;
            _academyProgramrepository = academyProgramrepository;
            _academyRepository = academyRepository;
        }

        public void Create(List<GroupStudentsViewModel> members)
        {
            if (!members.Any()) return;
            foreach (var member in members)
            {
                var domain = member.ToDomain();
                _groupStudentsRepository.Create(domain);
            }
        }

        public void Create(GroupMembersViewModel model, int groupId)
        {

            
            // Create Group Member : if model.UserTypeId == UserType.Student
            if (model.UserTypeId == (int)UserType.Student)
            {
                var student = _studentRepository.FindById(model.MemberId);
                if (student == null)
                    throw new Exception("student not found");

                var groupStudent = new GroupStudents() { 
                    GroupId = groupId,
                    StudentId = model.MemberId
                };
                _groupStudentsRepository.Create(groupStudent);
            }
            // Create Group Member : if model.UserTypeId == UserType.Mentor
            if (model.UserTypeId == (int)UserType.Mentor)
            {
                var mentor = _mentorRepository.FindById(model.MemberId);
                if (mentor == null)
                    throw new Exception("mentor not found");

                var groupMentor = new GroupMentors()
                {
                    GroupId = groupId,
                    MentorId = model.MemberId,
                    MentorTypeId = (int)Enum.Parse(typeof(MentorType), model.UserType)
            };
               _groupMentorsRepository.Create(groupMentor);
            }           
        }

        public void Delete(int groupMemberId, int userTypeId)
        {
            /* If:
             * 
                UserType = 0 delete from GroupStudents
                UserType = 1 delete from GroupMentors

             */
            if (userTypeId == (int)UserType.Student)
            {
                var studentFromGroup = _groupStudentsRepository.GetAll().FirstOrDefault(gm => gm.ID == groupMemberId);
                if (studentFromGroup == null)
                    throw new Exception("student in group is not found");
                _groupStudentsRepository.Delete(studentFromGroup);
            }
            else if (userTypeId == (int)UserType.Mentor)
            {
                var mentorFromGroup = _groupMentorsRepository.GetAll().FirstOrDefault(gm => gm.ID == groupMemberId);
                if (mentorFromGroup == null)
                    throw new Exception("student in group is not found");
                _groupMentorsRepository.Delete(mentorFromGroup);
            }
        }

        public GroupStudentsViewModel FindById(int apId)
        {
            var groupMember = _groupStudentsRepository.FindById(apId);
            if (groupMember == null)
                throw new Exception("Group member not found");
            return groupMember.ToModel();
        }

        public IEnumerable<GroupMembersViewModel> GetAll(int groupId)
        {
            var members = new List<GroupMembersViewModel>();

            var students =
                from gs in _groupStudentsRepository.GetAll().Where(gs => gs.GroupId == groupId)
                join s in _studentRepository.GetAll() on gs.StudentId equals s.ID
                select new GroupMembersViewModel
                {
                    Id = gs.ID,
                    MemberId = gs.StudentId,
                    UserTypeId = (int)UserType.Student,
                    UserType = (Enum.GetName(typeof(UserType), (int)UserType.Student)),
                    FullName = $"{ s.FirstName } { s.LastName}"
                };

            var mentors =
                from gm in _groupMentorsRepository.GetAll().Where(gm => gm.GroupId == groupId)
                join m in _mentorRepository.GetAll() on gm.MentorId equals m.ID
                select new GroupMembersViewModel
                {
                    Id = gm.ID,
                    MemberId = gm.MentorId,
                    UserTypeId = (int)UserType.Mentor,
                    UserType = (Enum.GetName(typeof(MentorType), (int)gm.MentorTypeId)) ,
                    FullName = $"{ m.FirstName } { m.LastName}"
                };

            members.AddRange(students);
            members.AddRange(mentors);

            return members;
        }

        public IEnumerable<GroupViewModel> GetGroupsByMember(int memberId, int userTypeId)
        {
            List<Group> groups;
            if (userTypeId == (int)UserType.Student)
            {
                groups = _groupStudentsRepository.GetAll()
                     .Where(g => g.StudentId == memberId)
                     .Select(a => _groupRepository.FindById(a.GroupId))
                     .Distinct()
                     .ToList();
            }
            else
            {
                // If Group member is Mentor
                groups = _groupMentorsRepository.GetAll()
                     .Where(g => g.MentorId == memberId)
                     .Select(a => _groupRepository.FindById(a.GroupId))
                     .Distinct()
                     .ToList();
            }

            var result = groups.Select(
                model =>
                {
                    model.AcademyProgram = _academyProgramrepository.FindById(model.AcademyProgramId);
                    model.AcademyProgram.Academy = _academyRepository.FindById(model.AcademyProgram.AcademyId);
                    return model.ToModel();
                }
            );
            return result;
        }

        public IEnumerable<GroupStudentsViewModel> GetMentorsAndStudents(int groupId, int academyProgramId)
        {
            var members = new List<GroupStudentsViewModel>();
            var student = _studentRepository.FindById(1);
            
            var groupMembers = _groupStudentsRepository.GetAll().Where(gm => gm.Group.AcademyProgramId == academyProgramId);

            // mentors
          /*  var mentorsByGroup = groupMembers.Where(gm => gm.GroupId == groupId && gm.UserType == (int)UserType.Mentor);
            var mentors = _mentorRepository.GetAll().Where(m => m.AcademyProgramId == academyProgramId && !mentorsByGroup.Any(gm => gm.UserId == m.ID)).Select(x => x.ToMentorViewModel()).ToList();

            // students
            var studentGroupMembers = groupMembers.Where(gm => gm.UserType == (int)UserType.Student);
            var students = _studentRepository.GetAll().Where(s => s.ApId == academyProgramId && !studentGroupMembers.Any(sgm => sgm.UserId == s.ID)).Select(x => x.ToGroupMemberModel()).ToList();

            members.AddRange(students);
            members.AddRange(mentors);*/

            return members;
        }
    }
}
