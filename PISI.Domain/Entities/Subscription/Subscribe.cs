using PISI.Domain.Entities.Common;
using PISI.Domain.Entities.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Entities.Subscription
{
    public class Subscribe : BaseEntity
    {
        public long Id { get; set; }
        public string ServiceId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSubcribed { get; set; }
    }
}
