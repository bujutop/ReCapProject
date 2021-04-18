using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BuyerValidator:AbstractValidator<Buyer>
    {
        public BuyerValidator()
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Name).MinimumLength(1);
            RuleFor(b => b.Surname).NotEmpty();
            RuleFor(b => b.Surname).MinimumLength(1);

        }
    }
}
