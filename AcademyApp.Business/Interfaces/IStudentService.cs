using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
    public interface IStudentService
    {
        void Create(StudentViewModel model);
        void Delete(StudentViewModel model);
        void Update(StudentViewModel model);
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel FindById(int apId);

    }
}
