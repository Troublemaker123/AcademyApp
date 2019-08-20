using System;
using Microsoft.AspNetCore.Mvc;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        [HttpGet]
        public ActionResult Create()
        {
            return Create();
        }
       
        public void List<AcademyProgramViewModel>()
        {
            _apService.GetAll();
        }
        [HttpPost]
        public void Update(AcademyProgramViewModel model)
        {
            _apService.Update(model);
        }
        [HttpPost]
        public void FindById(AcademyProgramViewModel model)
        {
            if(model == null)
            {
                throw new ApplicationException("Object is null");
            }
            _apService.FindById(apId);
        }
        // POST api/admin/ap
        [Route("ap")]
        [HttpPost]
        public void Create(AcademyProgramViewModel model)
        {
            if (model == null)
                throw new ApplicationException("Object is null");

            _apService.Create(model);
        }
        [HttpGet]
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
                return Create(new model());
            else
                return Create(_apService.FindById(apId));
        }
    }
}