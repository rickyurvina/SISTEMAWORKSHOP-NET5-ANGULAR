using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        
    }
}
