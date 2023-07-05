using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessCape.DTOs.Provider.Validators
{
    internal class ProviderCreateDtoValidator:AbstractValidator<ProviderCreateDto>
    {
        public ProviderCreateDtoValidator()
        {
            Regex regexOnlyLetters = new Regex(@"^[a-zA-Z]+$");
            Regex regexOnlyNumbers = new Regex(@"^[0-9]+$");

            // VALIDATION FOR NAMECOMPANY FIELD //
            RuleFor(x => x.NameCompany).NotNull().WithMessage("NameCompany can't be null");
            RuleFor(x => x.NameCompany).NotEmpty().WithMessage("NameCompany is required");
            RuleFor(x => x.NameCompany).Equal(x => x.NameCompany).WithMessage("There is already another supply with this name");
            RuleFor(x => x.NameCompany).MinimumLength(3).WithMessage("The NameCompany must contain more than 3 letters");
            RuleFor(x => x.NameCompany).MaximumLength(20).WithMessage("The NameCompany must contain less than 20 letters");
            RuleFor(x => x.NameCompany).Matches(regexOnlyLetters).WithMessage("The NameCompany is invalid");

            // VALIDATION FOR NitCompany FIELD //
            RuleFor(x => x.NitCompany).NotNull().WithMessage("NitCompany can't be null");
            RuleFor(x => x.NitCompany).NotEmpty().WithMessage("NitCompany is required");
            RuleFor(x => x.NitCompany).MinimumLength(5).WithMessage("The NitCompany must contain more than 5 letters");
            RuleFor(x => x.NitCompany).MaximumLength(10).WithMessage("The NitCompany must contain less than 255 letters");

            // VALIDATION FOR Email FIELD //
            RuleFor(x => x.Email).NotNull().WithMessage("Email can't be null");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("The Email must contain more than 10 letters");
            RuleFor(x => x.Email).MaximumLength(255).WithMessage("The Email must contain less than 255 letters");

            // VALIDATION FOR Phone FIELD //
            RuleFor(x => x.Phone).NotNull().WithMessage("Phone can't be null");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone is required");
            RuleFor(x => x.Phone).MinimumLength(10).WithMessage("The Phone must contain more than 10 letters");
            RuleFor(x => x.Phone).MaximumLength(255).WithMessage("The Phone must contain less than 255 letters");

            // VALIDATION FOR CompanyAddress FIELD //
            RuleFor(x => x.CompanyAddress).NotNull().WithMessage("CompanyAddress can't be null");
            RuleFor(x => x.CompanyAddress).NotEmpty().WithMessage("CompanyAddress is required");
            RuleFor(x => x.CompanyAddress).MinimumLength(10).WithMessage("The CompanyAddress must contain more than 10 letters");
            RuleFor(x => x.CompanyAddress).MaximumLength(255).WithMessage("The CompanyAddress must contain less than 255 letters");

        }
    }
}
