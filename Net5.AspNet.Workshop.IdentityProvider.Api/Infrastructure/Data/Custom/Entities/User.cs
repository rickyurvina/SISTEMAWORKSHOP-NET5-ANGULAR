using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities
{
    public partial class User
    {
        public virtual Person Person { get; set; }
        public virtual Category Category { get; set; }
    }
}
