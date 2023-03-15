using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Repositories
{
    public class SecurityUnitOfWork:UnitOfWork
    {
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }
        public IUserRoleRepository UserRoles { get; }
        public SecurityContext _context { get; }

        public SecurityUnitOfWork(
            SecurityContext context,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository
        ):base(context)
        {
            Users = userRepository;
            Roles = roleRepository;
            UserRoles = userRoleRepository;
        }
    }
}
