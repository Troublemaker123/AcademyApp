using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Model;
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
            _apRepository.Create(domain);

        }

        public IEnumerable<StudentViewModel> GetAll(int academyProgramId)
        {

            return _apRepository.GetAll().Where(student => student.ApId == academyProgramId)
                .Select(student => student.ToModel()).ToList();
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
            var students = _apRepository.FindByMultipleId(student.ID, student.AcademyProgramId);
            if (students == null)
                throw new Exception("student not found");

            students.Name = student.Name;
            students.LastName = student.LastName;
            students.Mobile = student.Mobile;
            students.PlaceOfBirth = student.PlaceOfBirth;
            students.EmailAdress = student.EmailAdress;
            students.Address = student.Address;
            students.DateOfBirth = student.DateOfBirth;
            students.Country = student.Country;
            students.DateOfEnrollment = student.DateOfEnrollment;
            students.GraduationYear = student.GraduationYear;

            _apRepository.Update(students);
        }

        public void Delete(int studentId, int academyProgramId)
        {
            var students = _apRepository.FindByMultipleId(studentId, academyProgramId);
            if (students == null)
                throw new Exception("student not found");

            _apRepository.Delete(students);
        }
    }
}
