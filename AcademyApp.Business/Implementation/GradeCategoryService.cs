using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class GradeCategoryService : IGradeCategoryService
    {
        private readonly IRepository<GradeCategory> _grRepository;

        public GradeCategoryService(IRepository<GradeCategory> grRepository)
        {
            _grRepository = grRepository;
        }

        public void Create(GradeCategoryViewModel model)
        {
            var domain = model.ToDomain();
            _grRepository.Create(domain);
        }

        public GradeCategoryViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AttendanceViewModel> GetAll()
        {
           
            return _grRepository.GetAll().Select(model => new AttendanceViewModel()
            {
                ID = model.ID
            }).ToList();
        }

        public void Update(GradeCategoryViewModel model)
        {
            var program = _grRepository.FindById(new GradeCategory());
            if (program == null)
                throw new Exception();
            _grRepository.Update(program);
        }
    }
}
