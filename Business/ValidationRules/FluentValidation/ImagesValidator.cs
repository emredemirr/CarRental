using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ImagesValidator:AbstractValidator<Images>
    {
        public ImagesValidator()
        {
            RuleFor(c => c.CarId).NotNull();
        }
    }
}
