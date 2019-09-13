using System;
using System.Collections.Generic;
using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademyProgramController : ControllerBase
    {
        private readonly IAcademyProgramService _academyProgramService;

        public AcademyProgramController(IAcademyProgramService academyProgramService)
        {
            _academyProgramService = academyProgramService;
        }

        [Route("create")]
        [HttpPost]
        public ActionResult Create(AcademyProgramViewModel academyProgram)
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
        [Route("delete/{apId}")]
        [HttpDelete]
        public ActionResult Delete(AcademyProgramViewModel academyProgram)
        {
           
            try
            {
                _academyProgramService.Delete(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }


        [Route("update")]
        [HttpPut]
        public ActionResult Update(AcademyProgramViewModel academyProgram)
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

        [Route("find-by-id/{apId}")]
        [HttpGet]
        public ActionResult<AcademyProgramViewModel> FindById(int academyProgramId)
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

        // api/academyprogram/get-all
        [Route("get-all")]
        [HttpGet]
        public ActionResult<List<AcademyProgramViewModel>> GetAll()
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

    }
}