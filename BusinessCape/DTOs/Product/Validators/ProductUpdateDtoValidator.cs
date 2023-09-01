using FluentValidation;
using System.Text.RegularExpressions;

namespace BusinessCape.DTOs.Product.Validators
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator() 
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

            // VALIDATION FOR TYPEPRODUCT FIELD //
            RuleFor(x => x.TypeProduct).NotNull().WithMessage("TypeProduct can't be null");
            RuleFor(x => x.TypeProduct).NotEmpty().WithMessage("TypeProduct is required");
            RuleFor(x => x.TypeProduct).MinimumLength(10).WithMessage("The typeProduct must contain more than 10 letters");
            RuleFor(x => x.TypeProduct).MaximumLength(255).WithMessage("The typeProduct must contain less than 255 letters");
        }
    }
}
