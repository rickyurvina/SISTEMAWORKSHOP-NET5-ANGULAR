using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class EnrollmentStateDto
    {
        public int EnrollmentStateId { get; set; }
        public string Description { get; set; }
        public string CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Deleted { get; set; }
    }
}
