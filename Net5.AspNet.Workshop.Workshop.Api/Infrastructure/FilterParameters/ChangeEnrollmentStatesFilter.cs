using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class ChangeEnrollmentStatesFilter
    {
        public ChangeEnrollmentStatesFilter()
        {
            EnrollmentIds = new List<int>();            
        }
        public List<int> EnrollmentIds { get; set; }
        public int enrollmentStateId { get; set; }        
    }
}
