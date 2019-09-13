
using System.Collections.Generic;
using AcademyApp.Business.ViewModel;


namespace AcademyApp.Business.Interfaces
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel academyProgram);
        void Delete(AcademyProgramViewModel academyProgram);
        void Update(AcademyProgramViewModel academyProgram);
        IEnumerable<AcademyProgramViewModel> GetAll();
        AcademyProgramViewModel FindById(int academyProgramId);
        void SetActive(int academyProgramId, bool active);
    }
}
