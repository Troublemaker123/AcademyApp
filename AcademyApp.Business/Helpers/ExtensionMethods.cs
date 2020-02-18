using AcademyApp.Business.ViewModel;
using AcademyApp.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyApp.Business.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UserViewModel> WithoutPasswords(this IEnumerable<UserViewModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserViewModel WithoutPassword(this UserViewModel user)
        {
            user.Password = null;
            return user;
        }
    }
}
