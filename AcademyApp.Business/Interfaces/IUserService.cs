using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IUserService
    {
        void Create(UserViewModel model);
        void Update(UserViewModel model);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel FindById(int apId);
    }
}
