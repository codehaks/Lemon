using FluentValidation;
using Portal.Application.FoodApplication.Commands.Create;

namespace Portal.Application.FoodApplication.Commands.Create
{
    public class FoodCreateCommandValidator : AbstractValidator<FoodCreateCommand>
    {
        public FoodCreateCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Food should have a name.");
            RuleFor(u => u.Price).GreaterThan(0).WithMessage("Food can not be free.");
            RuleFor(u => u.Description).NotEmpty().WithMessage("Food needs description");
        }
    }
}
