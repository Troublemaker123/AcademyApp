using AcademyApp.Business.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Validators
{
   public class UserLoginValidators : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginValidators()
        {
            RuleFor(x => x.UserName)
               .NotNull().WithMessage("Required field");

            RuleFor(x => x.Password)
               .NotNull().WithMessage("Required field");
        }
    }
}
