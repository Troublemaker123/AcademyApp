using System;


using AcademyApp.Business.Mapper;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.Interfaces;
using System.Linq;
using AcademyApp.Model;

namespace AcademyApp.Business
{
   public class MentorService : IMentorService
    {
        private readonly IRepository<Mentor> _apRepository;

        public MentorService(IRepository<Mentor> apRepository)
        {
            _apRepository = apRepository;
        }

        public void Create(MentorViewModel model)
        {
            var domain = model.ToDomain();
           _apRepository.Create(domain);
        }

        public IEnumerable<MentorViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public MentorViewModel FindById(int apId)
        {
            var program = _apRepository.FindById(apId);
            if (program == null)
                throw new Exception("Object not found");

            return program.ToModel();
        }

        public void Update(MentorViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception();

            program.Name = model.Name;
            program.LastName = model.LastName;
            program.Specialty = model.Specialty;
            program.Telephone = model.Telephone;
            program.YearsOfService = model.YearsOfService;
            program.Email = model.Email;

            _apRepository.Update(program);
        }

        public void Delete(MentorViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception("Object not found");

            program.ToModel();
            _apRepository.Delete(program);
        }
    }
}
