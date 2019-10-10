using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAcademyProgramService _academyProgramService;
        private readonly IStudentService _studentService;
        private readonly IMentorService _mentorService;
        private readonly ISubjectService _subjecService;
        private readonly IGroupService _groupService;
        private readonly IGroupMemberService _groupMemberService;

        public AdminController(
            IAcademyProgramService academyProgramService,
            IStudentService studentService,
            IMentorService mentorService,
            ISubjectService subService,
            IGroupService groupService,
            IGroupMemberService groupMemberService)
        {
            _academyProgramService = academyProgramService;
            _studentService = studentService;
            _mentorService = mentorService;
            _subjecService = subService;
            _groupService = groupService;
            _groupMemberService = groupMemberService;

        }

        //=========================================START OF CREATE========================================================
        #region Student 
        #endregion

        [Route("student/create")]
        [HttpPost]
        public ActionResult CreateStudent(StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _studentService.Create(student);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("academyProgram/create")]
        [HttpPost]
        public ActionResult CreateAcademyProgram(AcademyProgramViewModel academyProgram)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _academyProgramService.Create(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("mentor/create")]
        [HttpPost]
        public ActionResult CreateMentor(MentorViewModel mentor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _mentorService.Create(mentor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("subject/create")]
        [HttpPost]
        public ActionResult CreateSubject(SubjectViewModel subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _subjecService.Create(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("group/create")]
        [HttpPost]
        public ActionResult CreateGroup(GroupViewModel group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Create(group);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("groupMember/create")]
        [HttpPost]
        public ActionResult CreateGroupMember([FromBody] List<GroupMembersViewModel> members)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupMemberService.Create(members);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        //=========================================END OF CREATE===========================================================



        //=========================================START OF DELETE=========================================================
        [Route("academyProgram/delete/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteAcademyProgram(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _academyProgramService.Delete(academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("student/delete/{studentId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteStudent(int studentId, int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _studentService.Delete(studentId, academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("mentor/delete/{mentorId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteMentor(int mentorId, int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _mentorService.Delete(mentorId, academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("subject/delete/{subjectId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteSubject(int subjectId, int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _subjecService.Delete(subjectId, academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("group/delete/{groupId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteGroup(int groupId, int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Delete(groupId, academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("groupMember/delete/{groupMemberId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteGroupMember(int groupMemberId, int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupMemberService.Delete(groupMemberId, academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        //=========================================END OF DELETE===========================================================



        //=========================================START OF UPDATE=========================================================

        [Route("academyProgram/update")]
        [HttpPut]
        public ActionResult UpdateAcademyProgram(AcademyProgramViewModel academyProgram)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _academyProgramService.Update(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("student/update")]
        [HttpPut]
        public ActionResult UpdateStudent(StudentViewModel student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _studentService.Update(student);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("mentor/update")]
        [HttpPut]
        public ActionResult UpdateMentor(MentorViewModel mentor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _mentorService.Update(mentor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("subject/update")]
        [HttpPut]
        public ActionResult UpdateSubject(SubjectViewModel subject)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _subjecService.Update(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("group/update")]
        [HttpPut]
        public ActionResult UpdateGroup(GroupViewModel group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Update(group);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        //=========================================END OF UPDATE==============================================================



        //=========================================START OF FIND-BY-ID========================================================

        [Route("academyProgram/find-by-id/{academyProgramId}")]
        [HttpGet]
        public ActionResult<AcademyProgramViewModel> AcademyProgramFindById(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var program = _academyProgramService.FindById(academyProgramId);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("student/find-by-id/{studentId}")]
        [HttpGet]
        public ActionResult<StudentViewModel> StudentFindById(int studentId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var students = _studentService.FindById(studentId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [Route("mentor/find-by-id/{mentorId}")]
        [HttpGet]
        public ActionResult<MentorViewModel> MentorFindById(int mentorId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var mentors = _mentorService.FindById(mentorId);
                return Ok(mentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("subject/find-by-id/{subjectId}")]
        [HttpGet]
        public ActionResult<SubjectViewModel> SubjectFindById(int subjectId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var subject = _subjecService.FindById(subjectId);
                return Ok(subject);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("group/find-by-id/{groupId}")]
        [HttpGet]
        public ActionResult<GroupViewModel> GroupFindById(int groupId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var students = _groupService.FindById(groupId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("groupMember/find-by-id/{groupMemberId}")]
        [HttpGet]
        public ActionResult<GroupMembersViewModel> GroupMemberFindById(int groupMemberId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groupMembers = _groupMemberService.FindById(groupMemberId);
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        //=========================================END OF FIND-BY-ID=========================================================



        //=========================================START OF GET-ALL==========================================================
        [Route("academyProgram/get-all")]
        [HttpGet]
        public ActionResult<List<AcademyProgramViewModel>> GetAllAcademyPrograms()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var programs = _academyProgramService.GetAll();
                return Ok(programs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Route("student/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAllStudents(int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var students = _studentService.GetAll(academyProgramId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("mentor/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<MentorViewModel>> GetAllMentors(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var mentors = _mentorService.GetAll(academyProgramId);
                return Ok(mentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("subject/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<SubjectViewModel>> GetAllSubjects(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var subjects = _subjecService.GetAll(academyProgramId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("group/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<GroupViewModel>> GetAllGroups(int groupId, int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groups = _groupService.GetAll(academyProgramId);
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("groupMember/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<GroupMembersViewModel>> GetAllGroupMembers(int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groupMembers = _groupMemberService.GetAll(academyProgramId);
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("groupMember/getMentorsAndStudents/{groupId}/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<GroupMembersViewModel>> GetMentorsAndStudents(int groupId, int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groupMembers = _groupMemberService.GetMentorsAndStudents(groupId, academyProgramId);
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //=========================================END OF GET-ALL=========================================================


    }
}