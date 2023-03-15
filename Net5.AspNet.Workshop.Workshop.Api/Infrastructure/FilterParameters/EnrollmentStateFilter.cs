using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class EnrollmentStateFilter
    {
        public EnrollmentStateFilter()
        {
            EnrollmentStatesIds = new List<int>();            
        }
        public List<int> EnrollmentStatesIds { get; set; }        
    }
}
