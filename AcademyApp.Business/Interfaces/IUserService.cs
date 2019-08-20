using AcademyApp.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IUserService
    {
        void CreateStudent(UserViewModel model);
        void Update(UserViewModel model);
        List<UserViewModel> FindAll();
        UserViewModel FindById(int apId);
    }
}
