using AcademyApp.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface ICategoryService
    {
        void Create(CategoryViewModel model);
        void Update(CategoryViewModel model);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel FindById(int categoryId);
        void Delete(int categoryId);
    }
}
