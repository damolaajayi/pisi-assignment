using PISI.Domain.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Interfaces.Service
{
    public interface IService
    {
        Task<ResponseDto> Login(LoginDto login);
        
        Task<ResponseDto> CheckTokenExpiry(LoginDto login);
    }
}
