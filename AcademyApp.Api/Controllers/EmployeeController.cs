using AcademyApp.Api.Utility;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ValidateModel]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IAcademyService _academyService;
        private readonly IRoleService _roleService;
        private readonly IAcademyProgramService _academyProgramService;
        private readonly IStudentService _studentService;
        private readonly IMentorService _mentorService;
        private readonly ISubjectService _subjectService;
        private readonly IGroupService _groupService;
        private readonly IGroupMemberService _groupMemberService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IRatingService _ratingService;

        public EmployeeController(IAcademyService academyService, 
            IRoleService roleService, 
            IAcademyProgramService academyProgramService,
            IStudentService studentService,
            IMentorService mentorService,
            ISubjectService subService,
            IGroupService groupService,
            IGroupMemberService groupMemberService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IRatingService ratingService)
        {
            _academyService = academyService;
            _roleService = roleService;
            _academyProgramService = academyProgramService;
            _studentService = studentService;
            _mentorService = mentorService;
            _subjectService = subService;
            _groupService = groupService;
            _groupMemberService = groupMemberService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _ratingService = ratingService;
        }

        #region Academy
        [Route("academy/create")]
        [HttpPost]
        public ActionResult CreateAcademy(AcademyViewModel academy)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _academyService.Create(academy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("academy/delete/{academyId}")]
        [HttpDelete]
        public ActionResult DeleteAcademy(int academyId)
        {
            try
            {
                _academyService.Delete(academyId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("academy/find-by-id/{academyId}")]
        public ActionResult FindAcademyById(int academyId)
        {
            try
            {
                var academy = _academyService.FindById(academyId);
                return Ok(academy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("academy/get-all")]
        public IActionResult GetAllAcademies()
        {
            try
            {
                var academies = _academyService.GetAll();
                return Ok(academies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("academy/update")]
        [HttpPut]
        public IActionResult UpdateAcademy(AcademyViewModel academy)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _academyService.Update(academy);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region AcademyProgram
        [Route("academyProgram/create")]
        [HttpPost]
        public ActionResult CreateAcademyProgram(AcademyProgramViewModel academyProgram)
        {
            try
            {
                _academyProgramService.Create(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("academyProgram/delete/{academyProgramId}")]
        [HttpDelete]
        public ActionResult DeleteAcademyProgram(int academyProgramId)
        {
            try
            {
                _academyProgramService.Delete(academyProgramId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("academyProgram/update")]     
        [HttpPut]
        public ActionResult UpdateAcademyProgram(AcademyProgramViewModel academyProgram)
        {
            try
            {
                _academyProgramService.Update(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("academyProgram/find-by-id/{academyProgramId}")]
        [HttpGet]
        public ActionResult<AcademyProgramViewModel> AcademyProgramFindById(int academyProgramId)
        {
            try
            {
                var program = _academyProgramService.FindById(academyProgramId);
                return Ok(program);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("academyProgram/get-all")]
        [HttpGet]
        public ActionResult<List<AcademyProgramViewModel>> GetAllAcademyPrograms()
        {
            try
            {
                var programs = _academyProgramService.GetAll();
                return Ok(programs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion AcademyProgram

        #region Student
        [Route("student/create")]
        [HttpPost]
        public ActionResult CreateStudent(StudentViewModel student)
        {
            try
            {
                _studentService.Create(student);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("student/delete/{studentId}")]
        [HttpDelete]
        public ActionResult DeleteStudent(int studentId)
        {
            try
            {
                _studentService.Delete(studentId);
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
                _studentService.Update(student);
                return Ok();
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
                var students = _studentService.FindById(studentId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("student/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult GetAllStudents(int academyProgramId)
        {

            try
            {
                var students = _studentService.GetAll(academyProgramId);
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        #endregion Student

        #region Mentor
        [Route("mentor/create")]
        [HttpPost]
        public ActionResult CreateMentor(MentorViewModel mentor)
        {
            try
            {
                _mentorService.Create(mentor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("mentor/delete/{mentorId}")]
        [HttpDelete]
        public ActionResult DeleteMentor(int mentorId, int academyProgramId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _mentorService.Delete(mentorId);
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
        [Route("mentor/get-all")]
        [HttpGet]
        public ActionResult<List<MentorViewModel>> GetAllMentors(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var mentors = _mentorService.GetAll();
                return Ok(mentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("mentor/getBasicMentors/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<MentorBasicViewModel>> GetBasicMentors(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var basicMentors = _mentorService.GetAllBasicMentors(academyProgramId);
                return Ok(basicMentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        #endregion Mentor

        #region Subject
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
                _subjectService.Create(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("subject/delete/{subjectId}")]
        [HttpDelete]
        public ActionResult DeleteSubject(int subjectId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _subjectService.Delete(subjectId);
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
                _subjectService.Update(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [Route("subject/find-by-id/{subjectId}")]
        [HttpGet]
        public ActionResult SubjectFindById(int subjectId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var subject = _subjectService.FindById(subjectId);
                return Ok(subject);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("subject/get-all/{academyId}")]
        [HttpGet]
        public ActionResult GetAllSubjects(int academyId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var subjects = _subjectService.GetAll(academyId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        #endregion Subject

        #region Group
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
        [Route("group/delete/{groupId}")]
        [HttpDelete]
        public ActionResult DeleteGroup(int groupId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupService.Delete(groupId);
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
        [Route("group/find-by-id/{groupId}")]
        [HttpGet]
        public ActionResult GroupFindById(int groupId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groups = _groupService.FindById(groupId);
                return Ok(groups);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("group/get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult GetAllGroups(int academyProgramId)
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
        #endregion Group

        #region GroupMember
        [Route("groupMember/create/{groupId}")]
        [HttpPost]
        public ActionResult CreateGroupMember(int groupId, GroupMembersViewModel member)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupMemberService.Create(member, groupId);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("groupMember/delete/{groupMemberId}/{userTypeId}")]
        [HttpDelete]
        public ActionResult DeleteGroupMember(int groupMemberId, int userTypeId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _groupMemberService.Delete(groupMemberId, userTypeId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("groupMember/find-by-id/{groupMemberId}")]
        [HttpGet]
        public ActionResult<GroupStudentsViewModel> GroupMemberFindById(int groupMemberId)
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
        [Route("groupMember/get-all/{groupId}")]
        [HttpGet]
        public ActionResult GetAllGroupMembers(int groupId)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groupMembers = _groupMemberService.GetAll(groupId);
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("groupMember/getGroupsByMember/{memberId}/{userTypeId}")]
        [HttpGet]
        public ActionResult GetGroupsByMember(int memberId, int userTypeId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var groupMembers = _groupMemberService.GetGroupsByMember(memberId, userTypeId);
                return Ok(groupMembers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        #endregion GroupMember

        #region Category
        [Route("category/create")]
        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _categoryService.Create(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("category/delete/{categoryId}")]
        [HttpDelete]
        public ActionResult DeleteCategory(int categoryId)
        {
            try
            {
                _categoryService.Delete(categoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("category/find-by-id/{categoryId}")]
        public ActionResult FindCategoryById(int categoryId)
        {
            try
            {
                var category = _categoryService.FindById(categoryId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("category/get-all")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("category/update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryViewModel category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _categoryService.Update(category);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region SubCategory
        [Route("subcategory/create")]
        [HttpPost]
        public ActionResult CreateSubCategory(SubCategoryViewModel subcategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _subCategoryService.Create(subcategory);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("subcategory/delete/{subcategoryId}")]
        [HttpDelete]
        public ActionResult DeleteSubCategory(int subcategoryId)
        {
            try
            {
                _subCategoryService.Delete(subcategoryId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("subcategory/find-by-id/{categoryId}")]
        public ActionResult FindSubCategoryById(int categoryId)
        {
            try
            {
                var subcategory = _subCategoryService.FindById(categoryId);
                return Ok(subcategory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("subcategory/get-all/{categoryId}")]
        public IActionResult GetAllSubCategories(int categoryId)
        {
            try
            {
                var subcategories = _subCategoryService.GetAll(categoryId);
                return Ok(subcategories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("subcategory/update")]
        [HttpPut]
        public IActionResult UpdateSubCategory(SubCategoryViewModel subcategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _subCategoryService.Update(subcategory);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Rating
        [Route("rating/create")]
        [HttpPost]
        public ActionResult CreateRating(RatingViewModel rating)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _ratingService.Create(rating);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        [Route("rating/delete/{ratingId}")]
        [HttpDelete]
        public ActionResult DeleteRating(int ratingId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _ratingService.Delete(ratingId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [Route("rating/update")]
        [HttpPut]
        public ActionResult UpdateRating(RatingViewModel rating)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _ratingService.Update(rating);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [Route("rating/find-by-id/{ratingId}")]
        [HttpGet]
        public ActionResult RatingFindById(int ratingId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                var ratings = _ratingService.FindById(ratingId);
                return Ok(ratings);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }
        #endregion 


    }
}