using PISI.Domain.Entities.Service;
using PISI.Domain.Interfaces.IRepository;
using PISI.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PISI.Infrastructure.Repositories.Service
{
    public class ServiceRepository : BaseRepository<ServiceUser>, IServiceRepository
    {
        public ServiceRepository(PISIDbContext context): base(context) { }
    }
}   
