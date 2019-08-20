using AcademyApp.Business.ViewModel;
using System.Collections.Generic;

namespace AcademyApp.Business.Interfaces
{
   public interface IGradeService
    {
        void Create(GradeViewModel model);
        void Update(GradeViewModel model);
        GradeViewModel FindById(int apId);
        List<GradeViewModel> FindAll();
    }
    public interface IGradeCategory
    {
        void Create(GradeCategoryViewModel model);
        void Update(GradeCategoryViewModel model);
        GradeCategoryViewModel FindById(int apId);
        List<GradeCategoryViewModel> FindAll();

    }
}
