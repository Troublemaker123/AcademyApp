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
    public class GradeService : IGradeService
    {
        private readonly IRepository<Grade> _gRepository;
        public GradeService(IRepository<Grade> gRepository)
        {
            _gRepository = gRepository;
        }
        public void Create(GradeViewModel model)
        {
            var domain = model.ToDomain();
            _gRepository.Create(domain);
        }

        public IEnumerable<GradeViewModel> FindAll()
        {
           return _gRepository.GetAll().Select(model => new GradeViewModel(){
                ID = model.ID,
                Name = model.Name
            }).ToList();
        }

        public GradeViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(GradeViewModel model)
        {
            var program = _gRepository.FindById(new Grade());
            if (program == null)
                throw new Exception();
            _gRepository.Update(program);
        }
    }
}
