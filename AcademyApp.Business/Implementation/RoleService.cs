using AcademyApp.Business.Interfaces;
using AcademyApp.Business.Mapper;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{


    public class RoleService : IRoleService
    {
        private readonly IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public void Create(RoleViewModel model)
        {
            var domain = model.ToDomain();
            _roleRepository.Create(domain);
        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            return _roleRepository.GetAll().Select(
                model => model.ToModel()
          ).ToList();
        }

        public RoleViewModel FindById(int roleId)
        {
            var role = _roleRepository.FindById(roleId);
            if (role == null)
                throw new ApplicationException("Role not found.");

            return role.ToModel();
        }

        public void Update(RoleViewModel model)
        {
            var role = _roleRepository.FindById(model.ID);
            if (role == null)
                throw new Exception();
            role.Description = model.Description;

            _roleRepository.Update(role);
        }

        public void Delete(int roleId)
        {
            var role = _roleRepository.FindById(roleId);
            if (role == null)
                throw new Exception("Role not found");

            _roleRepository.Delete(role);
        }
    }
}
