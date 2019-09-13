using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface ISubjectService
    {
        void Create(SubjectViewModel model);
        void Delete(SubjectViewModel model);
        void Update(SubjectViewModel model);
        IEnumerable<SubjectViewModel> GetAll();
        SubjectViewModel FindById(int apId);
       
    }
}
