using PISI.Domain.Entities.Subscription;
using PISI.Domain.Interfaces.IRepository;
using PISI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Infrastructure.Repositories.Subcription
{
    public class SubscribeRepository : BaseRepository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(PISIDbContext context) : base(context)
        {
        }
    }
}
