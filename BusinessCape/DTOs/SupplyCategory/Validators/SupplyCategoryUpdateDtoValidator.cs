using BusinessCape.DTOs.Supply;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BusinessCape.DTOs.SupplyCategory.Validators
{
    public class SupplyCategoryUpdateDtoValidator : AbstractValidator<SupplyCategoryUpdateDto>
    {
        public SupplyCategoryUpdateDtoValidator()
        {
            Regex regexOnlyLetters = new Regex(@"^[a-zA-Z]+$");
            Regex regexOnlyNumbers = new Regex(@"^[0-9]+$");

            // VALIDATION FOR NAME FIELD //
            RuleFor(x => x.Name).NotNull().WithMessage("Name can't be null");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Name).Equal(x => x.Name).WithMessage("There is already another supply with this name");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("The name must contain more than 3 letters");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("The name must contain less than 20 letters");
            RuleFor(x => x.Name).Matches(regexOnlyLetters).WithMessage("The name is invalid");

            // VALIDATION FOR IDUNITMEASURE FIELD //
            RuleFor(x => x.Description).NotNull().WithMessage("Description can't be null");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("The description must contain more than 3 letters");
            RuleFor(x => x.Description).MaximumLength(255).WithMessage("The description must contain less than 20 letters");
        }
    }
}
