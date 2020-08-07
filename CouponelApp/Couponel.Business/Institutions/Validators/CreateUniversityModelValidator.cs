using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Business.Institutions.Universities.Models;
using FluentValidation;

namespace Couponel.Business.Institutions.Validators
{
    public class CreateUniversityModelValidator : AbstractValidator<CreateUniversityModel>
    {
        public CreateUniversityModelValidator()
        {
            RuleFor(university => university.Address)
                .NotEmpty()
                .NotNull();
            RuleFor(university => university.Email)
                .EmailAddress()
                .NotNull();
            RuleFor(university => university.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
