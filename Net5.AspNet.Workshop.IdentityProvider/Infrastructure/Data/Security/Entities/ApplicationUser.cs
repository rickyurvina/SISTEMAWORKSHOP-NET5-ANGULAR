using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public int? CategoryId { get; set; }
        public int PersonId { get; set; }
        public Category Category { get; set; }
        public Person Person { get; set; }
    }
}
