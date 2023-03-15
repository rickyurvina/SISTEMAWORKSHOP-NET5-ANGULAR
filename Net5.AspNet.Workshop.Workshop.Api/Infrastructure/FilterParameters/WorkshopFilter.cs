using Net5.AspNet.Workshop.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.FilterParameters
{
    public class WorkshopFilter
    {
        public WorkshopFilter()
        {
            CategoriesIds = new List<int>();
            WorkshopStatesIds = new List<int>();
        }
        public string Title { get; set; }
        public List<int> CategoriesIds { get; set; }
        public List<int> WorkshopStatesIds { get; set; }
        public int InstructorId { get; set; }

        public InstructorDto Instructor { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
