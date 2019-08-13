using System;


namespace AcademyApp.Business
{
    public class StudentService : IStudentService
    {
       // private readonly IRepository<Student> _studentRepository;

        public void CreateStudent(StudentViewModel student)
        {
            // viewModel => domain model
            //var stunt = new Student
            //{
            //    StudentID = student.StudentId
            //};

            //_studentRepository.Create(stunt);

            throw new NotImplementedException();
        }
    }
}
