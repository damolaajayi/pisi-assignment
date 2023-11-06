using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PISI.Domain.Interfaces.Service;
using PISI.Domain.Models.Service;
using PISI_MOBILE.Helpers;
using AuthorizeAttribute = PISI_MOBILE.Helpers.AuthorizeAttribute;

namespace PISI_MOBILE.Controllers
{
    [Route("api/v1/service/[Action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;
        public ServiceController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {

            var response = await _service.Login(login);
            return Ok(response);
        }

        

    }
}
