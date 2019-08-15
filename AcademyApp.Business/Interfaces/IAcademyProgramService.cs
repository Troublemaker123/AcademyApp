using AcademyApp.Business.ViewModels;


namespace AcademyApp.Business.Interfaces
{
    public interface IAcademyProgramService
    {
        void Create(AcademyProgramViewModel model);
     
        /*   void Update(AcademyProgramViewModel model);
List<AcademyProgramViewModel> FindAll();
AcademyProgramViewModel FindById(int apId);
void SetActivity(int apId, bool active);*/
    }
}
