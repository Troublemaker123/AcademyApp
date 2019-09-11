using System;
using Microsoft.AspNetCore.Mvc;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Collections.Generic;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAcademyProgramService _apService;

        public AdminController(IAcademyProgramService apService)
        {
            _apService = apService;
        }

        [Route("ap")]
        [HttpPost]
        public ActionResult Create(AcademyProgramViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _apService.Create(model);
            return Ok();
        }
        [Route("ap/{apId}")]
        [HttpDelete]
        public ActionResult Delete(AcademyProgramViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _apService.Delete(model);
            return Ok();
        }


        [Route("ap")]
        [HttpPut]
        public ActionResult Update(AcademyProgramViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _apService.Update(model);
            return Ok();
        }

        [Route("ap/{apId}")]
        [HttpGet]
        public ActionResult<AcademyProgramViewModel> FindById(int apId)
        {
            var program = _apService.FindById(apId);
            return Ok(program);
        }

        // api/admin/ap
        [Route("ap")]
        [HttpGet]
        public ActionResult<List<AcademyProgramViewModel>> GetAll()
        {
            var programs = _apService.GetAll();
            return Ok(programs);
        }

    }
}