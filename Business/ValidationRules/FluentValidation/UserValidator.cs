using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.EMail).NotEmpty();
            RuleFor(u => u.EMail).Must(EndsWithCom).WithMessage("Invalid email");
            RuleFor(u => u.EMail).EmailAddress();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password.Length).ExclusiveBetween(7,13);
            
        }

        private bool EndsWithCom(string arg)
        {
            return arg.EndsWith("com");
        }
    }
}
