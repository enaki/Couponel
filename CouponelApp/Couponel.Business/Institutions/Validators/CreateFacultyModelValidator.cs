using System;
using System.Collections.Generic;
using System.Text;
using Couponel.Business.Institutions.Faculties.Models;
using FluentValidation;

namespace Couponel.Business.Institutions.Validators
{
    public class CreateFacultyModelValidator : AbstractValidator<CreateFacultyModel>
    {
        public CreateFacultyModelValidator()
        {
            RuleFor(faculty => faculty.Address)
                .NotEmpty()
                .NotNull();
            RuleFor(faculty => faculty.Email)
                .EmailAddress()
                .NotNull();
            RuleFor(faculty => faculty.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);
        }
    }
}
