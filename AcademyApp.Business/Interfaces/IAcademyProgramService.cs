
using System.Collections.Generic;
using AcademyApp.Data.Model;
namespace AcademyApp.Business.ViewModel
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel model);
        void Update(AcademyProgramViewModel model);
        List<AcademyProgramViewModel> FindAll();
        AcademyProgramViewModel FindById(int apId);
    }
}
