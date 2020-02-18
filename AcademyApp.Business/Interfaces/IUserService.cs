using AcademyApp.Business.Mappers;
using AcademyApp.Business.ViewModel;
using AcademyApp.Business.ViewModels;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Interfaces
{
    public interface IUserService
    {
        void Create(UserViewModel model);
        void Update(UserViewModel model);
        void Delete(int userId);
        IEnumerable<UserViewModel> GetAll();
        UserViewModel FindById(int apId);
        UserViewModel Login(string username, string password);
        IEnumerable<User> GetActiveUsers();
        bool IsUserNameUnique(UserViewModel user,string username);
        User Authenticate(Guid userToken);
        void VerifyUserEmail(User user);
        UserViewModel FindUserByUsername(string username);
        void SendResetLinkToEmail(UserViewModel user);
        void SendChangedPassEmail(UserViewModel user);
        UserActivation CheckTokenAuth(Guid userToken, int type);
        UserViewModel ForgetPassword(Guid userToken, string newPassword);
        UserViewModel ChangePassword(ChangePasswordViewModel model);
        void ReSendLoginCredentials(int userId);
        void PrintLoginCredentials(int userId);
    }
}
