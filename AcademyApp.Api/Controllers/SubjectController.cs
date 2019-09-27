using System;
using System.Collections.Generic;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subService;

        public SubjectController(ISubjectService subService)
        {
            _subService = subService;
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create(SubjectViewModel subject)
        {
            try
            {
                _subService.Create(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [Route("delete/{subjectId}")]
        [HttpDelete]
        public ActionResult Delete(SubjectViewModel subject)
        {

            try
            {
                _subService.Delete(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        [Route("update")]
        [HttpPut]
        public ActionResult Update(SubjectViewModel subject)
        {
            try
            {
                _subService.Update(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }
        [Route("find-by-id/{subjectId}")]
        [HttpGet]
        public ActionResult<SubjectViewModel> FindById(int subjectId)
        {

            try
            {
                var subject = _subService.FindById(subjectId);
                return Ok(subject);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
           
        }

        // api/subject/sub
        [Route("get-all/{academyProgramId}")]
        [HttpGet]
        public ActionResult<List<SubjectViewModel>> GetAll(int academyProgramId)
        {
            try
            {
                var subjects = _subService.GetAll(academyProgramId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}