using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;


namespace AcademyApp.Business
{
    public interface IStudentService
    {
        void CreateStudent(StudentViewModel model);
        void Update(StudentViewModel model);
        List<StudentViewModel> FindAll();
        StudentViewModel FindById(int apId);

    }
}
