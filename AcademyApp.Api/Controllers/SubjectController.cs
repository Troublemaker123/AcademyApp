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
        [Route("sub")]
        [HttpPost]
        public ActionResult Create(SubjectViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _subService.Create(model);
            return Ok();
        }
        [Route("sub/{apId}")]
        [HttpDelete]
        public ActionResult Delete(SubjectViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _subService.Delete(model);
            return Ok();
        }

        [Route("sub")]
        [HttpPut]
        public ActionResult Update(SubjectViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _subService.Update(model);
            return Ok();
        }
        [Route("sub/{apId}")]
        [HttpGet]
        public ActionResult<SubjectViewModel> FindById(int apId)
        {
            var program = _subService.FindById(apId);
            return Ok(program);
        }

        // api/subject/sub
        [Route("sub")]
        [HttpGet]
        public ActionResult<List<SubjectViewModel>> GetAll()
        {
            var programs = _subService.GetAll();
            return Ok(programs);
        }

    }
}