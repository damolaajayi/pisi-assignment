using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Application.Dtos
{
    public class TokenDto
    {
        public string accessToken { get; set; }
        public DateTime expires { get; set; }
    }
}
