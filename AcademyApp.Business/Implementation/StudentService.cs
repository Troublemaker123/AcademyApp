using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
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

        public void CreateStudent(StudentViewModel student)
        {


            var domain = student.ToDomain();
            _apRepository.Create(domain);

        }

        public IEnumerable<StudentViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new StudentViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                LastName = model.LastName,
                PlaceOfBirth = model.PlaceOfBirth,
                Country = model.Country,
                Mobile = model.Mobile,
                EmailAdress = model.EmailAdress,
                GraduationYear = model.GraduationYear,
                DateOfBirth = model.DateOfBirth,
                DateOfEnrollment = model.DateOfEnrollment,

            }
          ).ToList();
        }

        public StudentViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentViewModel model)
        {
            var program = _apRepository.FindById(new Student());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }
    }
}
