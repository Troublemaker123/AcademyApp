using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<SubCategory> _subcategoryRepository;

        public CategoryService(IRepository<Category> categoryRepository, IRepository<SubCategory> subcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }
        public void Create(CategoryViewModel model)
        {
            var domain = model.ToDomain();
            _categoryRepository.Create(domain);
        }

        public void Delete(int cId)
        {
            var category = _categoryRepository.FindById(cId);
            if (category == null)
                throw new Exception("Category not found");

            _categoryRepository.Delete(category);
        }

        public CategoryViewModel FindById(int cId)
        {
            var category = _categoryRepository.FindById(cId);
            if (category == null)
                throw new ApplicationException("Category not found.");

            //var result = category.ToModel();
            category.SubCategories = _subcategoryRepository.GetAll().Where(c => c.CategoryId == cId).ToList();

            return category.ToModel(); 
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _categoryRepository.GetAll().Select(
               model =>
               {
                   model.SubCategories = _subcategoryRepository.GetAll().Where(c => c.CategoryId == model.ID).ToList();
                   return model.ToModel();
               }
            );
        }

        public void Update(CategoryViewModel model)
        {

            var category = _categoryRepository.FindById(model.ID);
            if (category == null)
                throw new Exception();

            category.Name = model.Name;

            _categoryRepository.Update(category);
        }
    }
}
