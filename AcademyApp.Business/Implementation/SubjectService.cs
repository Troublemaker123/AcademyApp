using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business.Implementation
{
    public class SubjectService : ISubjectService
    {


        private readonly IRepository<Subject> _apRepository;

        public SubjectService(IRepository<Subject> apRepository)
        {
            _apRepository = apRepository;
        }
        public void CreateStudent(SubjectViewModel model)
        {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

        public IEnumerable<SubjectViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new SubjectViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Description = model.Description,
            }
            ).ToList();
        }

        public SubjectViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(SubjectViewModel model)
        {
            var program = _apRepository.FindById(new Subject());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }
    }
}
