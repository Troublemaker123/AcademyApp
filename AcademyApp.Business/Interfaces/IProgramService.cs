using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
    public interface IProgramService
    {
        void Create(ProgramViewModel model);
        void Update(ProgramViewModel model);
        IEnumerable<ProgramViewModel> GetAll();
        ProgramViewModel FindById(int apId);
    }
}
