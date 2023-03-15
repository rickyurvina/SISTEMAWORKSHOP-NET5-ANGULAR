using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Repositories
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        private readonly LocationContext _context;
        public DistrictRepository(LocationContext context):base(context)
        {
            _context = context;
        }
    }
}
