using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AcademyApp.Business.ViewModel
{
  public  class UserViewModel
    {

        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; } = false;

        public int RoleId { get; set; }

        public string UserRole { get; set; }

        public string Token { get; set; }

        public string EmailAdress { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool IsPasswordChanged { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
    }


}
