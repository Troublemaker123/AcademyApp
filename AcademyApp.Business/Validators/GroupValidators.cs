using AcademyApp.Business.ViewModel;
using FluentValidation;


namespace AcademyApp.Business.Validators
{
    public class GroupValidators : AbstractValidator<GroupViewModel>
    {
        public GroupValidators()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Required field")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");
        }
    }
}
