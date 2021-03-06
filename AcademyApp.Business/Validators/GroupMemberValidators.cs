﻿using AcademyApp.Business.ViewModels;
using FluentValidation;


namespace AcademyApp.Business.Validators
{
    public class GroupMemberValidators : AbstractValidator<GroupMembersViewModel>
    {
        public GroupMemberValidators()
        {
            RuleFor(x => x.UserTypeId)
                .NotNull().WithMessage("Required field!");
        }
    }
}
