using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validatior,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validatior.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }
    }
}
