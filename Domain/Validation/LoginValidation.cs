using FluentValidation;
using TheBulbProject.Domain.DTOs.CreateDTOs;

namespace TheBulbProject.Domain.Validation
{
    public class LoginValidation : AbstractValidator<Login>
    {
        public LoginValidation()
        {
            

            RuleFor(dto => dto.Password)
                .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[@$!%*?&]").WithMessage("Password must contain at least one special character (@$!%*?&).");

            RuleFor(dto => dto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
