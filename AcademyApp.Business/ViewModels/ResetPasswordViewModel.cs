using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.ViewModels
{
    public class ResetPasswordViewModel
    {
        public Guid activationToken { get; set; }
        public string newPassword { get; set; }
    }
}
