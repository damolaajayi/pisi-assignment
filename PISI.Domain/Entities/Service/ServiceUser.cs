using PISI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Entities.Service
{
    public class ServiceUser : BaseEntity
    {
        public string ServiceId { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpiry { get; set; }

    }
}
