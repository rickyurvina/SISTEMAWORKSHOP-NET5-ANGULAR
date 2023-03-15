using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public partial class ProvinceDto
    {
        public ProvinceDto()
        {            
        }

        public int ProvinceId { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        public virtual DepartmentDto Department { get; set; }        
    }
}
