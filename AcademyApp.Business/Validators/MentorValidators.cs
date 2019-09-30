using AcademyApp.Business.ViewModel;
using FluentValidation;

namespace AcademyApp.Business.Validators
{
   public class MentorValidators : AbstractValidator<MentorViewModel>
    {
        public MentorValidators()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Required field!").MaximumLength(255).WithMessage("Maximum 255 characters!");
            RuleFor(x => x.LastName).NotNull().WithMessage("Required field!").MaximumLength(255).WithMessage("Maximum 255 characters!");
            RuleFor(x => x.Email).NotNull().WithMessage("Required field!").EmailAddress().WithMessage("Must be valid email address!");
            RuleFor(x => x.YearsOfService).NotNull().WithMessage("Required field!").MaximumLength(255).WithMessage("Maximum 255 characters!");
            RuleFor(x => x.Specialty).NotNull().WithMessage("Required field!").MaximumLength(255).WithMessage("Maximum 255 characters!");
            RuleFor(x => x.Telephone).NotNull().WithMessage("Required field!").MaximumLength(255).WithMessage("Maximum 255 characters!");
        }
    }
}
