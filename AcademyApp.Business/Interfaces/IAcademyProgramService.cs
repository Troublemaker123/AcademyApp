
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data.Model;



namespace AcademyApp.Business.Interfaces
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel model);
        void Update(AcademyProgramViewModel model);
        IEnumerable<AttendanceViewModel> GetAll();
        AcademyProgramViewModel FindById(string apId);
        void SetActive(bool active);
    }
}
