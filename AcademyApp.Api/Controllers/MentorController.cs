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
        public ActionResult Create(MentorViewModel mentor)
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
        [Route("delete/{mentorId}")]
        [HttpDelete]
        public ActionResult Delete(MentorViewModel mentor)
        {

            try
            {
                _mentorService.Delete(mentor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [Route("update")]
        [HttpPut]
        public ActionResult Update(MentorViewModel mentor)
        {
            try
            {
                _mentorService.Update(mentor);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("find-by-id/{mentorId}")]
        [HttpGet]
        public ActionResult<MentorViewModel> FindById(int mentorId)
        {
            try
            {
                var mentors = _mentorService.FindById(mentorId);
                return Ok(mentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //  api/mentor/get-all
        [Route("get-all")]
        [HttpGet]
        public ActionResult<List<MentorViewModel>> GetAll()
        {
            try
            {
                var mentors = _mentorService.GetAll();
                return Ok(mentors);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}