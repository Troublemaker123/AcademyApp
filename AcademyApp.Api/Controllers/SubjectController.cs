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
        private readonly ISubjectService _subjecService;

        public SubjectController(ISubjectService subService)
        {
            _subjecService = subService;
        }
        [Route("create")]
        [HttpPost]
        public ActionResult Create(SubjectViewModel subject)
        {
            try
            {
                _subjecService.Create(subject);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }
        [Route("delete/{subjectId}/{academyProgramId}")]
        [HttpDelete]
        public ActionResult Delete(int subjectId, int academyProgramId)
        {

            try
            {
                _subjecService.Delete(subjectId,academyProgramId);
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
                _subjecService.Update(subject);
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
                var subject = _subjecService.FindById(subjectId);
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
                var subjects = _subjecService.GetAll(academyProgramId);
                return Ok(subjects);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}