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
        public void Create(SubjectViewModel model)
        {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

        public IEnumerable<SubjectViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public SubjectViewModel FindById(int apId)
        {
            var program = _apRepository.FindById(apId);
            if (program == null)
                throw new Exception("Object not found");

            return program.ToModel();
        }

        public void Update(SubjectViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception();

            program.Name = model.Name;
            program.Description = model.Description;    

            _apRepository.Update(program);
        }

        public void Delete(SubjectViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception("Object not found");

            program.ToModel();
            _apRepository.Delete(program);
        }
    }
}
