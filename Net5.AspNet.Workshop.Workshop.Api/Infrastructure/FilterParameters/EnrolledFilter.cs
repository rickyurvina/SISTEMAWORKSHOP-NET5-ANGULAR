using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class EnrolledFilter
    {
        public EnrolledFilter()
        {
            Workshop = new WorkshopDto();
        }
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public WorkshopDto Workshop { get; set; }
    }
}
