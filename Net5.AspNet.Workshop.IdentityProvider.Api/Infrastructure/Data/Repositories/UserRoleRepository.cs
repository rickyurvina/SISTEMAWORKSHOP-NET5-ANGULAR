using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public class UserRoleRepository :GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly SecurityContext _context;
        public UserRoleRepository(SecurityContext context):base(context)
        {
            _context = context;            
        }
    }
}
