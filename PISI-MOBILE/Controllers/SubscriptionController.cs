using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PISI.Application.Services.Service;
using PISI.Domain.Interfaces.Service;
using PISI.Domain.Interfaces.Subscription;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using PISI.Domain.Models.Validation;
using PISI_MOBILE.Helpers;

namespace PISI_MOBILE.Controllers
{
    [Route("api/v1/subscription/[Action]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscription _subscription;
        private IValidator<SubscribeDto> _subscribeValidator;
        public SubscriptionController(ISubscription subscription, IValidator<SubscribeDto> subscribeValidator)
        {
            _subscription = subscription;
            _subscribeValidator = subscribeValidator;
        }

        [Authorize]
        [HttpPost]
        [ActionName("Subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeDto dto, CancellationToken token)
        {
            var validationResult = _subscribeValidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var validationMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                var errorresponse = new ValidationResponseModel { IsValid = false, ValidationMessages = validationMessages };
                return BadRequest(errorresponse);
            }

            var response = await _subscription.Subscribe(dto, token);
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        [ActionName("UnSubscribe")]
        public async Task<IActionResult> Unsubscribe(SubscribeDto dto, CancellationToken token)
        {
            var validationResult = _subscribeValidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var validationMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                var errorresponse = new ValidationResponseModel { IsValid = false, ValidationMessages = validationMessages };
                return BadRequest(errorresponse);
            }

            var response = await _subscription.UnSubscribe(dto, token);
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        [ActionName("CheckStatus")]
        public async Task<IActionResult> CheckStatus(SubscribeDto dto, CancellationToken token)
        {
            var validationResult = _subscribeValidator.Validate(dto);
            if (!validationResult.IsValid)
            {
                var validationMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                var errorresponse = new ValidationResponseModel { IsValid = false, ValidationMessages = validationMessages };
                return BadRequest(errorresponse);
            }

            var response = await _subscription.CheckStatus(dto, token);
            return Ok(response);
        }
    }
}
