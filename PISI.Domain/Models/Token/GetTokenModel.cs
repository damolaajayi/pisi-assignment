using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Models.Token
{
    public class GetTokenModel
    {
        public string Token { get; set; }
        public DateTime TokenExpiry { get; set; }
    }
}
