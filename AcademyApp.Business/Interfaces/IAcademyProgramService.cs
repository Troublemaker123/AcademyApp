
using System.Collections.Generic;

namespace AcademyApp.Business
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel model);
        void Update(AcademyProgramViewModel model);
        List<AcademyProgramViewModel> FindAll();
        AcademyProgramViewModel FindById(int apId);
    }
}
