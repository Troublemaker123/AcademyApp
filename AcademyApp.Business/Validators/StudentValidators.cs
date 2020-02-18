using AcademyApp.Business.ViewModel;
using FluentValidation;

namespace AcademyApp.Business.Validators
{
   public class StudentValidators : AbstractValidator<StudentViewModel>
    {
        public StudentValidators()
        {
            RuleFor(x => x.FirstName)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

        }
    }
}
