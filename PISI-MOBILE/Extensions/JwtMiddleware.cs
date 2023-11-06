using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PISI_MOBILE.Extensions
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate requestDelegate,IHttpContextAccessor httpContextAccessor, 
                             IConfiguration configuration)
        {
            _requestDelegate = requestDelegate;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }


        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            attachUserToContext(context, token);
            await _requestDelegate(context);

        }

        private void attachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var serviceId = jwtToken.Claims.First(x => x.Type == "serviceId").Value;
                context.Items["ServiceId"] = serviceId;
                
            }
            catch
            {
            }
        }

    }
}
