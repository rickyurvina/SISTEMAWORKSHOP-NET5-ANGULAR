using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class DepartmentDto
    {
        public DepartmentDto()
        {
            
        }

        public int DepartmentId { get; set; }
        public string Description { get; set; }
    }
}
