using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Model;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _apRepository;

        public StudentService(IRepository<Student> apRepository)
        {
            _apRepository = apRepository;
        }

        public void Create(StudentViewModel model)
        {
            var domain = model.ToDomain();
            domain.DateOfBirth = DateTime.Now;
            domain.DateOfEnrollment = DateTime.Now;
            domain.GraduationYear = DateTime.Now;
            _apRepository.Create(domain);

        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => model.ToModel()).ToList();
        }

        public StudentViewModel FindById(int apId)
        {
            var program = _apRepository.FindById(apId);
            if (program == null)
                throw new Exception("Object not found");

            return program.ToModel();
        }

        public void Update(StudentViewModel model)
        {
            var program = _apRepository.FindById(model.ID);
            if (program == null)
                throw new Exception();

            program.Name = model.Name;
            program.LastName = model.LastName;
            program.Mobile = model.Mobile;
            program.PlaceOfBirth = model.PlaceOfBirth;
            program.EmailAdress = model.EmailAdress;
            program.Address = model.Address;
            program.DateOfBirth = model.DateOfBirth;
            program.Country = model.Country;
            program.DateOfEnrollment = model.DateOfEnrollment;
            program.GraduationYear = model.GraduationYear;

            _apRepository.Update(program);
        }

        public void Delete(StudentViewModel model)
        {
            var program = _apRepository.FindById(model);
            if (program == null)
                throw new Exception("Object not found");

            program.ToModel();
            _apRepository.Delete(program);
        }
    }
}
