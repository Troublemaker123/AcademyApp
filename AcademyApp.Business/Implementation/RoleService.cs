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


    public class RoleService : IRoleService
    {
        private readonly IRepository<RoleService> _apRepository;

        public RoleService(IRepository<RoleService> apRepository)
        {
            _apRepository = apRepository;
        }
        public void Create(RoleViewModel model)
        {
            var domain = model.ToDomain();
            _apRepository.Create(domain);
        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new ProgramViewModel()
            {
                ID = model.ID,

            }
          ).ToList();
        }

        public RoleViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleViewModel model)
        {
            var program = _apRepository.FindById(new Role());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }
    }
}
