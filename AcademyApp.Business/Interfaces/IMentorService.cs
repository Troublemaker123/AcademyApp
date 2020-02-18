using AcademyApp.Business.ViewModel;
using System.Collections.Generic;


namespace AcademyApp.Business.Interfaces
{
    public interface IMentorService
    {
        void Create(MentorViewModel mentor);
        void Update(MentorViewModel mentor);
        IEnumerable<MentorViewModel> GetAll();
        MentorViewModel FindById(int mentorId);
        void Delete(int mentorId);
        IEnumerable<MentorBasicViewModel> GetAllBasicMentors(int academyProgramId);
    }
}
