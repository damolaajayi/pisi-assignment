using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PISI.Domain.Interfaces.IRepository;
using PISI.Domain.Interfaces.Token;
using PISI.Domain.Models.Service;
using PISI.Domain.Models.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Application.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceRepository _serviceRepository;
        public TokenService(IConfiguration configuration, IServiceRepository serviceRepository)
        {
            _configuration = configuration;
            _serviceRepository = serviceRepository;
        }

        public Task<DateTimeOffset> CheckTokenExpiry(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public async Task<GetTokenModel> CreateToken(LoginDto login)
        {
            var tokenresponse = new GetTokenModel();
            try
            {
                //var getokenexpiry = await _serviceRepository.Get(1, new CancellationToken());
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] 
                    { 
                        new Claim("serviceId", login.ServiceId)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);

                var jwtToken = tokenHandler.WriteToken(token);
                tokenresponse.Token = jwtToken;
                tokenresponse.TokenExpiry = DateTime.UtcNow.AddDays(7);
                return tokenresponse;
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
