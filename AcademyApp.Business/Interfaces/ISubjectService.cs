using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
    public interface ISubjectService
    {
        void Create(SubjectViewModel subject);
        void Delete(int subjectId);
        void Update(SubjectViewModel subject);
        IEnumerable<SubjectViewModel> GetAll(int academyId);
        SubjectViewModel FindById(int subjectId);
       
    }
}
