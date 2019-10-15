using AcademyApp.Business.ViewModels;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
   public interface IMentorSubjectService
    {
        void Create(List<MentorSubjectsViewModel> models);
        void Delete(int mentorSubjectId, int academyProgramId);
        IEnumerable<MentorSubjectsViewModel> GetAll(int mentorSubjectId, int academyProgramId);
        MentorSubjectsViewModel FindById(int apId);
        IEnumerable<MentorSubjectsViewModel> GetMentorsAndSubjects(int mentorSubjectId, int academyProgramId);
    }
}
