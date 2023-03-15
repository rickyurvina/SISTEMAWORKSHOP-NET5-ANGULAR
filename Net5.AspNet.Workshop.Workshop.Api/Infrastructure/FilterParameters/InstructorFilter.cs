using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class InstructorFilter
    {
        public InstructorFilter()
        {
            CategoriesIds = new List<int?>();
        }
        public string Name { get; set; }
        public List<int?> CategoriesIds { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
