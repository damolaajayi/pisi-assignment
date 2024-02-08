using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime DateCreated { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTimeOffset? DateUpdated { get; set; }

        [StringLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
