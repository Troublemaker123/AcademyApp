using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;

namespace AcademyApp.Business
{
    public class AcademyProgramService : IAcademyProgramService
    {
        private readonly IRepository<AcademyProgramService> _apRepository;

        public AcademyProgramService(IRepository<AcademyProgramService> apRepository)
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
       



        public List<AcademyProgramViewModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public AcademyProgramViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(AcademyProgramViewModel model)
        {
            throw new NotImplementedException();
        }


        /*  public List<AcademyProgramViewModel> FindAll()
          {
              throw new NotImplementedException();
              // return _apRepository.FindAll(new AcademyProgram())
          }

          public AcademyProgramViewModel FindById(int apId)
          {
              throw new NotImplementedException();
          }

          public void SetActivity(int apId, bool active)
          {
              var program = _apRepository.FindById(new AcademyProgram());
              if (program == null)
                  throw new Exception();

              program.IsCurrent = active;

              _apRepository.SetActivity(program);
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
          }*/
    }
}
