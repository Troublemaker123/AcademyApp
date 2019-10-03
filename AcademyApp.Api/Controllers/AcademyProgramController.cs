using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }

                _academyProgramService.Create(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("delete/{academyProgramId}")]
        [HttpDelete]
        public ActionResult Delete(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _academyProgramService.Delete(academyProgramId);
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
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
                _academyProgramService.Update(academyProgram);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("find-by-id/{academyProgramId}")]
        [HttpGet]
        public ActionResult<AcademyProgramViewModel> FindById(int academyProgramId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
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
                if (!ModelState.IsValid)
                {
                    throw new Exception(ModelState.ToString());
                }
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