using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace AcademyApp.Business
{
    public class AcademyProgramService : IAcademyProgramService
    {
        private readonly IRepository<AcademyProgram> _apRepository;

        public AcademyProgramService(IRepository<AcademyProgram> apRepository)
        {
            _apRepository = apRepository;
        }

        public void Create(AcademyProgramViewModel model)
        {
            var domain = model.ToDomain();
            domain.CreatedOn = DateTime.Now;
            domain.CreatedBy = "Admistrator";

            _apRepository.Create(domain);
        }

      public IEnumerable<AcademyProgramViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new AcademyProgramViewModel()
            {
                ID = model.ID,
                CreatedBy = model.CreatedBy,
                CreatedOn = model.CreatedOn,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsCurrent = model.IsCurrent
            }
            ).ToList();
        }
          

          public void SetActivity(bool active)
        {
            var program = _apRepository.FindById(new AcademyProgram());
            if (program == null)
                throw new Exception();

            program.IsCurrent = active;

            _apRepository.SetActivity(active);
        }

        public void Update(AcademyProgramViewModel model)
        {
            var program = _apRepository.FindById(new AcademyProgram());
            if (program == null)
                throw new Exception();

            program.StartDate = model.StartDate;
            program.EndDate = model.EndDate;
            program.IsCurrent = model.IsCurrent;

            _apRepository.Update(program);
        }

        public AcademyProgramViewModel FindById(string apId)
        {
            // List<AcademyProgramViewModel> ap = new List<AcademyProgramViewModel>();
            //  ap = (from ID in AcademyProgramViewModel select  ).FindById(apId);
            //  return ap;


            return _apRepository.FindById(apId).Select(model => new AcademyProgramViewModel()
            {
                apId = model.apId
            } 
            ).ToList();
        }
    }

}
