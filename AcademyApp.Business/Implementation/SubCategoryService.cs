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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<SubCategory> _subcategoryRepository;

        public SubCategoryService(IRepository<Category> categoryRepository, IRepository<SubCategory> subcategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
        }

        public void Create(SubCategoryViewModel model)
        {
            var domain = model.ToDomain();
            domain.Category = _categoryRepository.FindById(model.CategoryId);
            _subcategoryRepository.Create(domain);
        }

        public void Delete(int subcategoryId)
        {
            var subCategory = _subcategoryRepository.FindById(subcategoryId);
            if (subCategory == null)
                throw new Exception("SubCategory not found");

            _subcategoryRepository.Delete(subCategory);
        }

        public SubCategoryViewModel FindById(int subcategoryId)
        {
            var subCategory = _subcategoryRepository.FindById(subcategoryId);
            if (subCategory == null)
                throw new ApplicationException("SubCategory not found.");
            subCategory.Category = _categoryRepository.FindById(subCategory.CategoryId);

            return subCategory.ToModel();
        }

        public IEnumerable<SubCategoryViewModel> GetAll(int categoryId)
        {
            var uList = _subcategoryRepository.GetAll().Where(c => c.CategoryId == categoryId).ToList();
            var resultList = uList.Select(
                    model =>
                    {
                        model.Category = _categoryRepository.FindById(categoryId);
                        return model.ToModel();
                    }
                );
            return resultList;
        }

        public void Update(SubCategoryViewModel model)
        {
            var subCategory = _subcategoryRepository.FindById(model.ID);
            if (subCategory == null)
                throw new ApplicationException("SubCategory not found.");

            subCategory.Name = model.Name;
            subCategory.CategoryId = model.CategoryId;
            _subcategoryRepository.Update(subCategory);
        }
    }
}
