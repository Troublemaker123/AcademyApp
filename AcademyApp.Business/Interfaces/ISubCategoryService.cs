using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
   public interface ISubCategoryService
    {
        void Create(SubCategoryViewModel model);
        void Update(SubCategoryViewModel model);
        IEnumerable<SubCategoryViewModel> GetAll(int categoryId);
        SubCategoryViewModel FindById(int subcategoryId);
        void Delete(int subcategoryId);
    }
}
