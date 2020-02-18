using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyApp.Business
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _apRepository;
        private readonly IRepository<User> _userRepository;

        public StudentService(IRepository<Student> apRepository, IRepository<User> userRepository)
        {
            _apRepository = apRepository;
            _userRepository = userRepository;
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

            return _apRepository.GetAll().Where(student => !student.AcademyProgramId.HasValue || (student.AcademyProgramId.HasValue && student.AcademyProgramId == academyProgramId))
                .Select(student => student.ToModel()).ToList();
        }

        public StudentViewModel FindById(int studentId)
        {
            var student = _apRepository.FindById(studentId);
            if (student == null)
                throw new Exception("student not found");

            return student.ToModel();
        }

        public void Update(StudentViewModel model)
        {
            var student = _apRepository.FindById(model.ID);
            if (student == null)
                throw new Exception("student not found");

            student.FirstName = model.FirstName;
            student.LastName = model.LastName;
            student.Mobile = model.Mobile;
            student.PlaceOfBirth = model.PlaceOfBirth;
            student.EmailAdress = model.EmailAdress;
            student.Address = model.Address;
            student.DateOfBirth = model.DateOfBirth;
            student.Country = model.Country;
            student.DateOfEnrollment = model.DateOfEnrollment;
            student.GraduationYear = model.GraduationYear;
            student.GenderId = model.GenderId;
            student.AcademyProgramId = model.AcademyProgramId;
            _apRepository.Update(student);
        }

        public void Delete(int studentId)
        {
            var student = _apRepository.FindById(studentId);
            if (student == null)
                throw new Exception("student not found");
            var user = _userRepository.FindById(student.UserId);          

            _apRepository.Delete(student);
            if (user != null)
                _userRepository.Delete(user);
        }
    }
}
