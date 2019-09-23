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

        public void Create(StudentViewModel student)
        {
            if (student == null)
                throw new Exception("student not found");

            var domain = student.ToDomain();
            domain.ApId = 5;
            domain.Address = "adasa";
            _apRepository.Create(domain);

        }

        public IEnumerable<StudentViewModel> GetAll()
        {

            return _apRepository.GetAll().Select(student => student.ToModel()).ToList();
        }

        public StudentViewModel FindById(int studentId)
        {
            var student = _apRepository.FindById(studentId);
            if (student == null)
                throw new Exception("student not found");

            return student.ToModel();
        }

        public void Update(StudentViewModel student)
        {
            var students = _apRepository.FindById(student.ID);
            if (students == null)
                throw new Exception("student not found");

            students.Name = students.Name;
            students.LastName = students.LastName;
            students.Mobile = students.Mobile;
            students.PlaceOfBirth = students.PlaceOfBirth;
            students.EmailAdress = students.EmailAdress;
            students.Address = students.Address;
            students.DateOfBirth = students.DateOfBirth;
            students.Country = students.Country;
            students.DateOfEnrollment = students.DateOfEnrollment;
            students.GraduationYear = students.GraduationYear;

            _apRepository.Update(students);
        }

        public void Delete(StudentViewModel student)
        {
            var students = _apRepository.FindById(student);
            if (students == null)
                throw new Exception("student not found");

            students.ToModel();
            _apRepository.Delete(students);
        }
    }
}
