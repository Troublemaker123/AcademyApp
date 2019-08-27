
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;


namespace AcademyApp.Business.Interfaces
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel model);
        void Update(AcademyProgramViewModel model);
        IEnumerable<AcademyProgramViewModel> GetAll();
        AcademyProgramViewModel FindById(int apId);
        void SetActive(int apId, bool active);
    }
}
