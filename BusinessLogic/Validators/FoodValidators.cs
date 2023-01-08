using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class FoodValidators : AbstractValidator<FoodDto>
    {
        public FoodValidators()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(5, 50);
            RuleFor(x => x.Description).NotNull().NotEmpty().Length(5, 200);
            RuleFor(x => x.Image).NotNull().NotEmpty().Length(5,200);
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Weight).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Category).NotNull().NotEmpty().Length(3, 20);
        }
    }
}
