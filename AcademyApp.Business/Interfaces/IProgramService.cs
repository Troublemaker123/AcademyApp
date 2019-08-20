using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
    public interface IProgramService
    {
        void Create(ProgramViewModel model);
        void Update(ProgramViewModel model);
        List<ProgramViewModel> FindAll();
        ProgramViewModel FindById(int apId);
    }
}
