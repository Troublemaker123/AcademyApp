﻿using AcademyApp.Business.Interfaces;
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

        public void Create(GroupMembersViewModel groupMember)
        {

            //List<GroupMembers> addGroupMembers = new List<GroupMembers>();
            //addGroupMembers = (from addGroupMembers in _groupMembersRepository.)

           // var selectedValue = groupMember.AddGroupMember.Where(x =>x.IsChecked ==true).ToList<AddGroupMember>


            //var countChecked = 0; var countUnChecked = 0;
            //for (int i = 0; i < groupMember.Count(); i++)
            //{
            //    if(groupMember[i].AddGroupMember == true)
            //    {
            //        countChecked = countChecked + 1;
            //    }else
            //    {
            //        countUnChecked = countUnChecked + 1;
            //    }
            //}
            if (groupMember == null)
                throw new Exception("student not found");

            var domain = groupMember.ToDomain();
            _groupMembersRepository.Create(domain);
        }

        public void Delete(int groupMemberId, int academyProgramId)
        {
           // var group = _groupMembersRepository.FindByMultipleId(groupMemberId, academyProgramId);
            var group = _groupMembersRepository.GetAll().FirstOrDefault(gm => gm.Id == groupMemberId && gm.ApId == academyProgramId && gm.GroupId == groupMemberId);
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

        public IEnumerable<GroupMembersViewModel> GetMentorsAndStudents(int academyProgramId)
        {
            var members = new List<GroupMembersViewModel>();

            var students = _studentRepository.GetAll().Where(groupMember => groupMember.ApId == academyProgramId).Select(x => x.ToGroupMemberModel()).ToList();
            var mentors = _mentorRepository.GetAll().Where(groupMember => groupMember.ApId == academyProgramId).Select(x => x.ToGroupMemberModel()).ToList();

            members.AddRange(students);
            members.AddRange(mentors);

            return members;
        }

    }
}
