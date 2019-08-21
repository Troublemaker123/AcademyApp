using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;


namespace AcademyApp.Business
{
    public interface IMentorService
    {
        void Create(MentorViewModel model);
        void Update(MentorViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        MentorViewModel FindById(string apId);
    }
}
