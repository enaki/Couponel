using Couponel.Business.Identities.Users.Models;
using FluentValidation;

namespace Couponel.Business.Identities.Users.Validators
{
    public class UserRegisterModelValidator : AbstractValidator<UserRegisterModel>
    {
        public UserRegisterModelValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(user => user.UserName)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(150)
                .NotNull();
                
            RuleFor(user => user.Password)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150);

            RuleFor(user => user.FirstName)
                .NotEmpty()
                .NotNull();

            RuleFor(user => user.LastName)
                .NotEmpty()
                .NotNull();

            RuleFor(user => user.PhoneNumber)
                .NotEmpty();

            RuleFor(user => user.Role)
                .Must(BeValidRole).WithMessage("Invalid Role. Available roles: Student, Offerer and Admin");
        }

        private static bool BeValidRole(string role)
        {
            return role == "Student" || role == "Offerer" || role == "Admin";
        }
    }
}
