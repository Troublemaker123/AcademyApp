using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class ProgramService : IProgramService
    {

        private readonly IRepository<Program> _apRepository;

        public ProgramService(IRepository<Program> apRepository)
        {
            _apRepository = apRepository;
        }
        public void Create(ProgramViewModel model)
        {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

        public ProgramViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProgramViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new ProgramViewModel()
            {
                ID = model.ID,

            }
           ).ToList();
        }

        public void Update(ProgramViewModel model)
        {
            var program = _apRepository.FindById(new Program());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }
    }
}
