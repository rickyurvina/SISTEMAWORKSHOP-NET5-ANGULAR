using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Infrastructure.Data.Base;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Repositories
{
    public class EnrollmentStateRepository : GenericRepository<EnrollmentState>, IEnrollmentStateRepository
    {
        private readonly WorkshopContext _context;        
        public EnrollmentStateRepository(WorkshopContext context) : base(context)
        {
            _context = context;            
        }
                
        public List<EnrollmentState> ListEnrollmentStates(EnrollmentStateFilter enrollmentStateFilter)
        {
            var query = from es in _context.EnrollmentStates
                        select es;
                        
            if (enrollmentStateFilter.EnrollmentStatesIds.Any())
            {
                query = query.Where(es => enrollmentStateFilter.EnrollmentStatesIds.Contains(es.EnrollmentStateId));
            }

            List<EnrollmentState> enrollmentStates = query.ToList();

            return enrollmentStates;
        }
    }
}
