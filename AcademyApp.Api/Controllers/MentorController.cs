using System;
using System.Collections.Generic;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MentorController : ControllerBase
    {
        private readonly IMentorService _mentorService;

        public MentorController(IMentorService mentorService)
        {
            _mentorService = mentorService;
        }

        [Route("create")]
        [HttpPost]
        public ActionResult Create(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Create(model);
            return Ok();
        }
        [Route("delete/{apId}")]
        [HttpDelete]
        public ActionResult Delete(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Delete(model);
            return Ok();
        }


        [Route("update")]
        [HttpPut]
        public ActionResult Update(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Update(model);
            return Ok();
        }

        [Route("find-by-id/{apId}")]
        [HttpGet]
        public ActionResult<MentorViewModel> FindById(int apId)
        {
            var program = _mentorService.FindById(apId);
            return Ok(program);
        }

        //  api/mentor/get-all
        [Route("get-all")]
        [HttpGet]
        public ActionResult<List<MentorViewModel>> GetAll()
        {
            var programs = _mentorService.GetAll();
            return Ok(programs);
        }

    }
}