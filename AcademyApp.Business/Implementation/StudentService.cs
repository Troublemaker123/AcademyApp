using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;

namespace AcademyApp.Business
{
    public class StudentService : IStudentService
    {
       private readonly IRepository<Student> _studentRepository;

        public void CreateStudent(StudentViewModel student)
        {
            // viewModel => domain model
            var stud = new Student
            {
                ID = student.ID
            };

            _studentRepository.Create(stud);

        }

        public List<StudentViewModel> FindAll()
        {
            throw new NotImplementedException();
        }

        public StudentViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
