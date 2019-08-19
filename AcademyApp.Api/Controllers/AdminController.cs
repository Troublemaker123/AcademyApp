using System;
using Microsoft.AspNetCore.Mvc;

using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModels;
using AcademyApp.Business;
using AcademyApp.Data.Model;

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
        /*
        [HttpGet]
        public async Task<AcademyProgramViewModel> FindById(int? apId)
        {
            if (apId == null)
            {
                return BadRequest();
            }
            try
            {
                var findid = await IAcademyProgramService.FindById(apId);
                if (findid == null)
                { return NotFound(); }
                return Ok(apId);
                
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }*/


        // POST api/admin/ap
        [Route("ap")]
        [HttpPost]
        public void Create(AcademyProgramViewController model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _apService.Create(model);
        }
    }
}