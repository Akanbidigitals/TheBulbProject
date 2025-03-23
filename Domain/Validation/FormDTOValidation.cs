using FluentValidation;
using TheBulbProject.Domain.DTOs.CreateDTOs;

namespace TheBulbProject.Domain.Validation
{
    public class FormDTOValidation : AbstractValidator<CreateFormDTO>
    {
        public FormDTOValidation()
        {
            RuleFor(dto => dto.FormTitle)
                .NotEmpty().WithMessage("FormTitle is required");

            RuleFor(dto => dto.FormType)
                .NotEmpty().WithMessage("Name is required");

        }
    }
}
