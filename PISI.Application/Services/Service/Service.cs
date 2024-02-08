using PISI.Domain.Interfaces.IRepository;
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
        private readonly IServiceRepository _serviceRepository;
        public Service(ITokenService tokenService, IServiceRepository serviceRepository)
        {
            _tokenService = tokenService;
            _serviceRepository = serviceRepository;
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
                var serviceId = await _serviceRepository.GetByExpressionAsync(x => x.ServiceId == login.ServiceId && x.Password == login.Password, new CancellationToken());
                if(serviceId != null)
                {
                    var token = await _tokenService.CreateToken(login);
                    serviceId.TokenExpiry = token.TokenExpiry;
                    await _serviceRepository.UpdateAsync(serviceId);
                    response.ResponseMessage = "Login successful";
                    response.ResponseCode = 200;
                    response.Data = token.Token;
                }
                else
                {
                    response.ResponseCode = 401;
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
