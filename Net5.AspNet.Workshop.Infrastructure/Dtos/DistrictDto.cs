using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class DistrictDto
    {
        public DistrictDto()
        {            
        }

        public int DistrictId { get; set; }
        public string Description { get; set; }
        public int ProvinceId { get; set; }

        public virtual ProvinceDto Province { get; set; }        
    }
}
