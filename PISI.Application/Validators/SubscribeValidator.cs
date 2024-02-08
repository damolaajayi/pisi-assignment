using FluentValidation;
using PISI.Domain.Models.Subscription;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Application.Validators
{
    public class SubscribeValidator : AbstractValidator<SubscribeDto>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.phoneNumber).NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(IsAPhoneNumber).WithMessage("{PropertyName} is invalid");

            RuleFor(x => x.ServiceId).NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} is longer than max. length of 50.");

        }

        private bool IsAPhoneNumber(string value)
        {
            return value.Length >= 10 && value.Length <= 14 && long.TryParse(value, out long _);
        }
    }
}
