using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
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
            domain.CreatedBy = "Administrator";

            _apRepository.Create(domain);
        }

        public IEnumerable<AcademyProgramViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public void Update(AcademyProgramViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception();

            program.StartDate = model.StartDate;
            program.EndDate = model.EndDate;
            program.IsCurrent = model.IsCurrent;

            _apRepository.Update(program);
        }

        public AcademyProgramViewModel FindById(int apId)
        {
            var program = _apRepository.FindById(apId);
            if (program == null)
                throw new Exception("Object not found");

            return program.ToModel();
        }

        public void SetActive(int apId, bool active)
        {
            var program = _apRepository.FindById(apId);
            if (program == null)
                throw new Exception();

            program.IsCurrent = active;

            _apRepository.SetActivity(active);
        }

        public void Delete(AcademyProgramViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception("Object not found");

             program.ToModel();
            _apRepository.Delete(program);
        }
    }

}
