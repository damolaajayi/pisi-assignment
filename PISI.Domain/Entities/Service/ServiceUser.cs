using PISI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Entities.Service
{
    public class ServiceUser : BaseEntity
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public double TokenExpiry { get; set; }

    }
}
