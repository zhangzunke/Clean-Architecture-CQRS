using FluentValidation;
using Social.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Domain.Validators.UserProfileValidators
{
    public class BasicInfoValidator : AbstractValidator<BasicInfo>
    {
        public BasicInfoValidator() 
        {
            RuleFor(info => info.FirstName)
                .NotNull().WithMessage("First name is required. It is currently null")
                .MinimumLength(3).WithMessage("First name must be at least 3 characters long")
                .MaximumLength(50).WithMessage("First nae can contain at most 50 characters long");

            RuleFor(info => info.LastName)
                .NotNull().WithMessage("Last name is required. It is currently null")
                .MinimumLength(3).WithMessage("Last name must be at least 3 characters long")
                .MaximumLength(50).WithMessage("Last nae can contain at most 50 characters long");

            RuleFor(info => info.EmailAddress)
                .NotNull().WithMessage("Email address is required. It is currently null")
                .EmailAddress().WithMessage("Provided string is not a correct email address format");

            RuleFor(info => info.DateOfBirth)
                .InclusiveBetween(new DateTime(1930, 1, 1), new DateTime(2024, 3, 1))
                .WithMessage("You need to be at least 18 years old");
        }
    }
}
