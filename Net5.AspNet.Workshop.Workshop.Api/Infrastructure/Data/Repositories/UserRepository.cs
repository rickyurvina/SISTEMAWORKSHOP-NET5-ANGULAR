using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Constants;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly WorkshopContext _context;
        public UserRepository(WorkshopContext context) : base(context)
        {
            _context = context;            
        }

        public List<User> ListInstructors(InstructorFilter instructorFilter)
        {
            var query = from u in _context.Users
                        join ur in _context.UserRoles on u.Id equals ur.UserId
                        where ur.Role.Name == Roles.Instructor
                        select u;

            if (!string.IsNullOrEmpty(instructorFilter.Name))
            {
                query = query.Where(u => u.Person.FirstName.Contains(instructorFilter.Name) || u.Person.LastName.Contains(instructorFilter.Name) || u.Person.SurName.Contains(instructorFilter.Name));
            }

            if (instructorFilter.CategoriesIds.Any())
            {
                query = query.Where(u => instructorFilter.CategoriesIds.Contains(u.CategoryId));
            }

            if (!string.IsNullOrEmpty(instructorFilter.IdentificationNumber))
            {
                query = query.Where(u => u.Person.IdentificationNumber.Contains(instructorFilter.IdentificationNumber));
            }

            query = query
                        .Include(u => u.Person)
                        .Include(u => u.Category);

            List<User> users = query.ToList();

            return users;
        }
    }
}
