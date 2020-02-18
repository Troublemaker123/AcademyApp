using AcademyApp.Business.ViewModel;
using FluentValidation;

namespace AcademyApp.Business.Validators
{
   public class AcademyProgramValidators : AbstractValidator<AcademyProgramViewModel>
    {
        public AcademyProgramValidators()
        {
            RuleFor(x => x.StartDate)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.EndDate)
                .NotNull().WithMessage("Required field!")
                .GreaterThan(x => x.StartDate)
                .WithMessage("End date must be after Start date");
        }
    }
}
