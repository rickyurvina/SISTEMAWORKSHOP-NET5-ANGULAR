using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class FileDatumRepository : GenericRepository<FileDatum>, IFileDatumRepository
    {
        private readonly WorkshopContext _context;        
        public FileDatumRepository(WorkshopContext context) : base(context)
        {
            _context = context;            
        }        
    }
}
