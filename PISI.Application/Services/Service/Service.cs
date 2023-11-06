using PISI.Domain.Interfaces.Service;
using PISI.Domain.Interfaces.Token;
using PISI.Domain.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Application.Services.Service
{
    public class Service : IService
    {
        private readonly ITokenService _tokenService;
        public Service(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public Task<ResponseDto> CheckTokenExpiry(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> Login(LoginDto login)
        {
            var response = new ResponseDto();
            try
            {
                var serviceId = login.ServiceId.ToLower();
                var password = login.Password.ToLower();
                if(serviceId == password)
                {
                    var token = await _tokenService.CreateToken(login);
                    response.ResponseMessage = "Login successful";
                    response.ResponseCode = 200;
                    response.Data = token;
                }
                else
                {
                    response.ResponseCode = 400;
                    response.ResponseMessage = "Service Id and password does not match";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 500;
                response.ResponseMessage = $"An error occurred: {ex.Message}";
                return response;
            }
            return response;
        }
    }
}
