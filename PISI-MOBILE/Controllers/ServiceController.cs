using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PISI.Application.Validators;
using PISI.Domain.Interfaces.Service;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Subscription;
using PISI.Domain.Models.Validation;
using PISI_MOBILE.Helpers;
using AuthorizeAttribute = PISI_MOBILE.Helpers.AuthorizeAttribute;

namespace PISI_MOBILE.Controllers
{
    [Route("api/v1/service/[Action]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IService _service;
        private IValidator<LoginDto> _loginValidator;

        public ServiceController(IService service, IValidator<LoginDto> loginValidator)
        {
            _service = service;
            _loginValidator = loginValidator;
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var validationResult = _loginValidator.Validate(login);
            if (!validationResult.IsValid)
            {
                var validationMessages = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                var errorresponse = new ValidationResponseModel { IsValid = false, ValidationMessages = validationMessages };
                return BadRequest(errorresponse);
            }

            var response = await _service.Login(login);
            return Ok(response);
        }

        

    }
}
