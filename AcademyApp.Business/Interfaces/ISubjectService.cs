using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
    public interface ISubjectService
    {
        void Create(SubjectViewModel subject);
        void Delete(int subjectId,int academyProgramId);
        void Update(SubjectViewModel subject);
        IEnumerable<SubjectViewModel> GetAll(int academyProgramId);
        SubjectViewModel FindById(int subjectId);
       
    }
}
