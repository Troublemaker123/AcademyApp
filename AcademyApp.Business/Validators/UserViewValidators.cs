using AcademyApp.Business.Interfaces;
using AcademyApp.Business.ViewModel;
using AcademyApp.Data.Domains;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyApp.Business.Validators
{
    public class UserViewValidators : AbstractValidator<UserViewModel>
    {
        private readonly IUserService _userService;
        public UserViewValidators(IUserService userService)
        {
            _userService = userService;

            RuleFor(x => x.UserName)
               .NotNull()
               .WithMessage("Required field!")
               .Must(_userService.IsUserNameUnique)
               .WithMessage("Username already exists!");

            RuleFor(x => x.RoleId)
             .NotNull()
             .WithMessage("Required field!");

            RuleFor(x => x.EmailAdress)
             .NotNull()
             .WithMessage("Required field!");
        }


    }
}
