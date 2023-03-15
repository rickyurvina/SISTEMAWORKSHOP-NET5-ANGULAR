using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class EnrollmentFilter
    {
        public EnrollmentFilter()
        {
            EnrollmentStatesIds = new List<int>();            
        }
        public string WorshopTitle { get; set; }
        public string EnrolledName { get; set; }
        public List<int> EnrollmentStatesIds { get; set; }
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkshopId { get; set; }
        public int EnrolledId { get; set; }

        public string EnrolledIdentificationNumber { get; set; }
        public WorkshopDto Workshop { get; set; }
    }
}
