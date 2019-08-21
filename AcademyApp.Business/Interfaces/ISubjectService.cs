using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface ISubjectService
    {
        void CreateStudent(SubjectViewModel model);
        void Update(SubjectViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        SubjectViewModel FindById(int apId);
    }
}
