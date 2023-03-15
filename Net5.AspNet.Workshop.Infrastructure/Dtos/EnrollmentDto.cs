using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class EnrollmentDto
    {
        public int EnrollmentId { get; set; }
        public int EnrolledId { get; set; }
        public int WorkshopId { get; set; }        
        public DateTime EnrollmentDate { get; set; }
        public int EnrollmentStateId { get; set; }

        public virtual EnrolledDto Enrolled { get; set; }
        public virtual WorkshopDto Workshop  { get; set; }
        public virtual EnrollmentStateDto EnrollmentState { get; set; }
    }
}
