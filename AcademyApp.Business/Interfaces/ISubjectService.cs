using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface ISubjectService
    {
        void Create(SubjectViewModel subject);
        void Delete(SubjectViewModel subject);
        void Update(SubjectViewModel subject);
        IEnumerable<SubjectViewModel> GetAll();
        SubjectViewModel FindById(int subjectId);
       
    }
}
