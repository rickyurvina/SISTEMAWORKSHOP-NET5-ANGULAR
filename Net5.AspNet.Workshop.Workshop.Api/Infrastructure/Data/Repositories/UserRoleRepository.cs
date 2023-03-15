using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {
        private readonly WorkshopContext _context;        
        public UserRoleRepository(WorkshopContext context) : base(context)
        {
            _context = context;
        }
    }
}
