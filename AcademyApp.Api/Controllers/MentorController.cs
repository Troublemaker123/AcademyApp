using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyApp.Business;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Http;
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

        [Route("me")]
        [HttpPost]
        public ActionResult Create(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Create(model);
            return Ok();
        }
        [Route("me/{apId}")]
        [HttpDelete]
        public ActionResult Delete(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Delete(model);
            return Ok();
        }


        [Route("me")]
        [HttpPut]
        public ActionResult Update(MentorViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _mentorService.Update(model);
            return Ok();
        }

        [Route("me/{apId}")]
        [HttpGet]
        public ActionResult<MentorViewModel> FindById(int apId)
        {
            var program = _mentorService.FindById(apId);
            return Ok(program);
        }

        //  api/mentor/me
        [Route("me")]
        [HttpGet]
        public ActionResult<List<MentorViewModel>> GetAll()
        {
            var programs = _mentorService.GetAll();
            return Ok(programs);
        }

    }
}