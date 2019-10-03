using AcademyApp.Business.ViewModel;
using FluentValidation;

namespace AcademyApp.Business.Validators
{
   public class AcademyProgramValidators : AbstractValidator<AcademyProgramViewModel>
    {
        public AcademyProgramValidators()
        {
            RuleFor(x => x.CreatedBy)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.CreatedOn)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.IsCurrent)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("Required field!");
        }
    }
}
