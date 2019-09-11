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

        [Route("st")]
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _studentService.Create(model);
            return Ok();
        }

        [Route("st/{apId}")]
        [HttpDelete]
        public ActionResult Delete(StudentViewModel model)
        {
            if (model == null)
                throw new Exception("Object not found");

            _studentService.Delete(model);
            return Ok();
        }

        [Route("st")]
        [HttpPut]
        public ActionResult Update(StudentViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _studentService.Update(model);
            return Ok();
        }

        [Route("st/{apId}")]
        [HttpGet]
        public ActionResult<StudentViewModel> FindById(int apId)
        {
            var program = _studentService.FindById(apId);
            return Ok(program);
        }

        // POST api/student/st
        [Route("st")]
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAll()
        {
            var programs = _studentService.GetAll();
            return Ok(programs);
        }


    }
}