using FluentValidation;
using Portal.Application.Foods.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portal.Application.Foods
{
    public class FoodAddValidator: AbstractValidator<FoodAddInfo>
    {
        public FoodAddValidator()
        {
            RuleFor(u => u.Name).NotEmpty().WithMessage("Food should have a name.");
            RuleFor(u => u.Price).GreaterThan(0).WithMessage("Food can not be free.");
            RuleFor(u => u.Description).NotEmpty().WithMessage("Food needs description");
        }
    }
}
