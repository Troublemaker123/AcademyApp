using System;
using Microsoft.AspNetCore.Mvc;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Collections.Generic;

namespace AcademyApp.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("create")]
        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            try
            {
                //if (modelstate.isvalid)
                    _studentService.Create(student);
                    return Ok();
                
            }
            catch (Exception ex) 
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("delete/{studentId}")]
        [HttpDelete]
        public ActionResult Delete(StudentViewModel student)
        {
            try
            {
                _studentService.Delete(student);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update(StudentViewModel student)
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

        [Route("find-by-id/{studentId}")]
        [HttpGet]
        public ActionResult<StudentViewModel> FindById(int studentId)
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

        // POST api/student/get-all
        [Route("get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAll(int academyProgramId)
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


    }
}