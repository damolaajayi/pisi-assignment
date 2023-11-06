using Microsoft.AspNetCore.Mvc;
using PISI.Application.Services.Service;
using PISI.Domain.Interfaces.Service;
using PISI.Domain.Interfaces.Subscription;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using PISI_MOBILE.Helpers;

namespace PISI_MOBILE.Controllers
{
    [Route("api/v1/subscription/[Action]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscription _subscription;
        public SubscriptionController(ISubscription subscription)
        {
            _subscription = subscription;
        }

        [Authorize]
        [HttpPost]
        [ActionName("Subscribe")]
        public async Task<IActionResult> Subscribe(SubscribeDto dto, CancellationToken token)
        {

            var response = await _subscription.Subscribe(dto, token);
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        [ActionName("UnSubscribe")]
        public async Task<IActionResult> Unsubscribe(SubscribeDto dto, CancellationToken token)
        {

            var response = await _subscription.UnSubscribe(dto, token);
            return Ok(response);
        }


        [Authorize]
        [HttpPost]
        [ActionName("CheckStatus")]
        public async Task<IActionResult> CheckStatus(SubscribeDto dto, CancellationToken token)
        {

            var response = await _subscription.CheckStatus(dto, token);
            return Ok(response);
        }
    }
}
