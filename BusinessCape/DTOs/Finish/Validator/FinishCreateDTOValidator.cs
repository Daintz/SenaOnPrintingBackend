using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;



namespace BusinessCape.DTOs.Finish.Validator
{
    public  class FinishCreateDTOValidator : AbstractValidator<FinishDtoCreate>
    {

        public FinishCreateDTOValidator()
        {

            Regex regexOnlyLetters = new Regex(@"^[a-zA-Z]+$");
      
        // VALIDATION FOR NAME FIELD //
        RuleFor(x => x.Name).NotNull().WithMessage("Name can't be null");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).Equal(x => x.Name).WithMessage("There is already another finish  with this name");
        RuleFor(x => x.Name).MinimumLength(3).WithMessage("The name must contain more than 3 letters");
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("The name must contain less than 20 letters");
        RuleFor(x => x.Name).Matches(regexOnlyLetters).WithMessage("The name is invalid");

    }
}
}