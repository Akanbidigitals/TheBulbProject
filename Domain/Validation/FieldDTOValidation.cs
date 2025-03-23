using FluentValidation;
using TheBulbProject.Domain.DTOs.CreateDTOs;

namespace TheBulbProject.Domain.Validation
{
    public class FieldDTOValidation : AbstractValidator<CreateFieldDTO>
    {
        public FieldDTOValidation()
        {
            RuleFor(dto => dto.Label).NotEmpty().WithMessage("Label cant be null");
        }
    }
}
