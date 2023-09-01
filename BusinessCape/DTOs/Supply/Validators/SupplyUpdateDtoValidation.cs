using FluentValidation;
using System.Text.RegularExpressions;

namespace BusinessCape.DTOs.Supply.Validators 
{
    public class SupplyUpdateDtoValidator : AbstractValidator<SupplyUpdateDto>
{
    public SupplyUpdateDtoValidator()
    {
        //Regex regexOnlyLetters = new Regex(@"^[a-zA-Z]+$");
        //Regex regexOnlyNumbers = new Regex(@"^[0-9]+$");

        //// VALIDATION FOR NAME FIELD //
        //RuleFor(x => x.Name).NotNull().WithMessage("Name can't be null");
        //RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        //RuleFor(x => x.Name).Equal(x => x.Name).WithMessage("There is already another supply with this name");
        //RuleFor(x => x.Name).MinimumLength(3).WithMessage("The name must contain more than 3 letters");
        //RuleFor(x => x.Name).MaximumLength(20).WithMessage("The name must contain less than 20 letters");
        //RuleFor(x => x.Name).Matches(regexOnlyLetters).WithMessage("The name is invalid");

        //// VALIDATION FOR IDUNITMEASURE FIELD //
        ////RuleFor(x => x.IdUnitMeasure).NotNull().WithMessage("IdUnitMeasure can't be null");
        ////RuleFor(x => x.IdUnitMeasure).NotEmpty().WithMessage("IdUnitMeasure is required");
        ////RuleFor(x => x.IdUnitMeasure).Must(x => x == 0).WithMessage("IdUnitMeasure value 0 is invalid");

        //// VALIDATION FOR DANGERINDICATORS FIELD //
        //RuleFor(x => x.DangerIndicators).NotNull().WithMessage("DangerIndicators can't be null");
        //RuleFor(x => x.DangerIndicators).NotEmpty().WithMessage("DangerIndicators is required");
        //RuleFor(x => x.DangerIndicators).MinimumLength(10).WithMessage("The dangerIndicators must contain more than 10 letters");
        //RuleFor(x => x.DangerIndicators).MaximumLength(255).WithMessage("The dangerIndicators must contain less than 255 letters");

        //// VALIDATION FOR USEINSTRUCTIONS FIELD //
        //RuleFor(x => x.UseInstructions).NotNull().WithMessage("UseInstructions can't be null");
        //RuleFor(x => x.UseInstructions).NotEmpty().WithMessage("UseInstructions is required");
        //RuleFor(x => x.UseInstructions).MinimumLength(10).WithMessage("The useInstructions must contain more than 10 letters");
        //RuleFor(x => x.UseInstructions).MaximumLength(255).WithMessage("The useInstructions must contain less than 255 letters");

        //// VALIDATION FOR ADVICES FIELD //
        //RuleFor(x => x.Advices).NotNull().WithMessage("Advices can't be null");
        //RuleFor(x => x.Advices).NotEmpty().WithMessage("Advices is required");
        //RuleFor(x => x.Advices).MinimumLength(10).WithMessage("The advices must contain more than 10 letters");
        //RuleFor(x => x.Advices).MaximumLength(255).WithMessage("The advices must contain less than 255 letters");

        //// VALIDATION FOR SUPPLYTYPE FIELD //
        //RuleFor(x => x.SupplyType).NotNull().WithMessage("SupplyType can't be null");
        //RuleFor(x => x.SupplyType).NotEmpty().WithMessage("SupplyType is required");
        //RuleFor(x => x.SupplyType).Must(x => x == 0).WithMessage("SupplyType value 0 is invalid");

        //// VALIDATION FOR SORTINGWORD FIELD //
        //RuleFor(x => x.SortingWord).NotNull().WithMessage("SortingWord can't be null");
        //RuleFor(x => x.SortingWord).NotEmpty().WithMessage("SortingWord is required");
        //RuleFor(x => x.SortingWord).Must(x => x == 0).WithMessage("SortingWord value 0 is invalid");

        //// VALIDATION FOR QUANTITY FIELD //
        //RuleFor(x => x.Quantity).NotNull().WithMessage("SortingWord can't be null");
        //RuleFor(x => x.Quantity).NotEmpty().WithMessage("SortingWord is required");
        //RuleFor(x => x.Quantity).Must(x => x == 0).WithMessage("SortingWord value 0 is invalid");

        //// VALIDATION FOR AVERAGECOST FIELD //
        //RuleFor(x => x.AverageCost).NotNull().WithMessage("AverageCost can't be null");
        //RuleFor(x => x.AverageCost).NotEmpty().WithMessage("AverageCost is required");
        //RuleFor(x => x.AverageCost).Must(x => x == 0).WithMessage("AverageCost value 0 is invalid");

        //// VALIDATION FOR QUANTITY FIELD //
        ////RuleFor(x => x.IdWarehouse).NotNull().WithMessage("IdWarehouse can't be null");
        ////RuleFor(x => x.IdWarehouse).NotEmpty().WithMessage("IdWarehouse is required");
        ////RuleFor(x => x.IdWarehouse).Must(x => x == 0).WithMessage("IdWarehouse value 0 is invalid");

        //// VALIDATION FOR STATEDAT FIELD //
        //RuleFor(x => x.StatedAt).NotNull().WithMessage("StatedAt can't be null");
        //RuleFor(x => x.StatedAt).NotEmpty().WithMessage("StatedAt is required");
        //RuleFor(x => x.StatedAt).Must(x => x == true || x == false).WithMessage("StatedAt value is invalid");
    }
}
}
