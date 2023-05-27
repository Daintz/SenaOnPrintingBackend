using FluentValidation;

namespace BusinessCape.DTOs.Supply.Validators
{
    public class SupplyCreateDtoValidator : AbstractValidator<SupplyCreateDto>
    {
        public SupplyCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(10);
        }
    }

}
