using FluentValidation;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Application.Validators
{
    public class LogInValidator : AbstractValidator<LoginDto>
    {
        public LogInValidator()
        {
            RuleFor(x => x.ServiceId).NotEmpty().WithMessage("{PropertyName} is required.")
                .WithMessage("{PropertyName} is invalid");

            RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} is required.")
              .WithMessage("{PropertyName} is longer than max. length of 50.");

        }


    }
}
