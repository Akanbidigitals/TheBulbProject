using FluentValidation;
using TheBulbProject.Domain.DTOs.CreateDTOs;

namespace TheBulbProject.Domain.Validation
{
    public class SignUpValidation : AbstractValidator<SignUp>
    {
        public SignUpValidation()
        {
            RuleFor(f => f.Email).NotEmpty().EmailAddress().WithMessage("Email adddress is required");

            RuleFor(f => f.PhoneNumber).NotEmpty().MinimumLength(11).WithMessage("Phone number must be greater than 11 digit");

            RuleFor(dto => dto.Password)
               .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(6).WithMessage("Password must be at least 8 characters long.")
           .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
           .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
           .Matches(@"[@$!%*?&]").WithMessage("Password must contain at least one special character (@$!%*?&).");

            RuleFor(dto => dto.ConfirmPassword)
               .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(6).WithMessage("Password must be at least 8 characters long.")
           .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
           .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
           .Matches(@"[@$!%*?&]").WithMessage("Password must contain at least one special character (@$!%*?&).");
        }
    }
}
