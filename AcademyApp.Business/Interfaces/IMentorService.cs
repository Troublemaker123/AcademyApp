using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;


namespace AcademyApp.Business
{
    public interface IMentorService
    {
        void Create(MentorViewModel model);
        void Update(MentorViewModel model);
        IEnumerable<MentorViewModel> GetAll();
        MentorViewModel FindById(int mentorId);
    }
}
