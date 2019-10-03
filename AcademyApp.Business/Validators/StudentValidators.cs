using AcademyApp.Business.ViewModel;
using FluentValidation;

namespace AcademyApp.Business.Validators
{
   public class StudentValidators : AbstractValidator<StudentViewModel>
    {
        public StudentValidators()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.LastName)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.Address)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.PlaceOfBirth)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.Gender)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.Mobile)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.Country)
                .NotNull().WithMessage("Required field!")
                .MaximumLength(255).WithMessage("Maximum 255 characters!");

            RuleFor(x => x.EmailAdress)
                .NotNull().WithMessage("Required field!")
                .EmailAddress().WithMessage("Must be valid email address!");

            RuleFor(x => x.GraduationYear)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.DateOfBirth)
                .NotNull().WithMessage("Required field!");

            RuleFor(x => x.DateOfEnrollment)
                .NotNull().WithMessage("Required field!");
        }
    }
}
