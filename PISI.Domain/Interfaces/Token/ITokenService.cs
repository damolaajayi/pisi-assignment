using PISI.Domain.Models.Service;
using PISI.Domain.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Interfaces.Token
{
    public interface ITokenService
    {
        Task<GetTokenModel> CreateToken(LoginDto appUser);
        Task<DateTimeOffset> CheckTokenExpiry(LoginDto login);
    }
}
