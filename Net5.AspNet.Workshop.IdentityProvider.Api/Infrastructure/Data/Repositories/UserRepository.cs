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
    public class UserRepository:GenericRepository<User>, IUserRepository
    {
        private readonly SecurityContext _context;
        private IPasswordHasher _passwordHasher;
        public IPasswordHasher PasswordHasher
        {
            get
            {
                return _passwordHasher;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _passwordHasher = value;
            }
        }

        public UserRepository(SecurityContext context):base(context)
        {
            _context = context;
            PasswordHasher = new PasswordHasher();
        }

        public User GetUserByUserName(string userName)
        {
            User user = _context.Users.Where(u => u.UserName == userName)
                            .Include(u => u.Person.Address.Department)
                            .Include(u => u.Person.Address.Province)
                            .Include(u => u.Person.Address.District)
                            .Include(u => u.Category)
                            .Include(u => u.UserRoles)
                                .ThenInclude(ur =>ur.Role)
                            .FirstOrDefault();

            return user;
        }

        public User UpdatePassword(string userName, string newPassword)
        {
            User user = _context.Users.Where(u => u.UserName == userName).FirstOrDefault();
            user.PasswordHash = PasswordHasher.HashPassword(newPassword);

            return user;
        }

    }
}
