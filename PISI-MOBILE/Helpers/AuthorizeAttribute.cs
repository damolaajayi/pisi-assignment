using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PISI.Domain.Models.Service;

namespace PISI_MOBILE.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public async void OnAuthorization(AuthorizationFilterContext context)
        {

            var serviceId = context.HttpContext.Items["ServiceId"];
            if (serviceId == null)
            {
                context.Result = new JsonResult(new { ResponseMessage = "Unauthorized. Please enter a valid token in the header", ResponseCode = 401}) { StatusCode = StatusCodes.Status401Unauthorized };
            }


        }
    }
}
