using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eProjectDemoViewModel.System.Users
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("FullName is required")
                .MaximumLength(100).WithMessage("Full name can not over 100 characters");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot greater than 100 year");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
              .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$") //paltem
              .WithMessage("Email format not match");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(4).WithMessage("Password is at least 4 characters");

            RuleFor(x => x).Custom((request, context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm password is not match");
                }
            });
        }
    }
}
