using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
  public interface IGradeCategoryService
    {
        
            void Create(GradeCategoryViewModel model);
            void Update(GradeCategoryViewModel model);
            GradeCategoryViewModel FindById(int apId);
            IEnumerable<GradeCategoryViewModel> GetAll();

    }
}
