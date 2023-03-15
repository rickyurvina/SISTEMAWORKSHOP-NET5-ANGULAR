using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly SecurityContext _context;        
        public RoleRepository(SecurityContext context) : base(context)
        {
            _context = context;            
        }
    }
}
