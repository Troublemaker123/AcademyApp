using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data;
using AcademyApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Implementation
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _apRepository;

        public UserService(IRepository<User> apRepository)
        {
            _apRepository = apRepository;
        }
        public void Create(UserViewModel model)
        {
            var domain = new User();
            _apRepository.Create(domain);
        }


        public UserViewModel FindById(int apId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _apRepository.GetAll().Select(model => new UserViewModel()
            {
                ID = model.ID,
                Name = model.Name,
                Password = model.Password
            }
           ).ToList();
        }

        public void Update(UserViewModel model)
        {
            var program = _apRepository.FindById(new User());
            if (program == null)
                throw new Exception();

            _apRepository.Update(program);
        }
    }
}
