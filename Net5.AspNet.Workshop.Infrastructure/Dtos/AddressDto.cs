using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class AddressDto
    {
        public AddressDto()
        {            
        }

        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }

        public virtual DepartmentDto Department { get; set; }
        public virtual DistrictDto District { get; set; }
        public virtual ProvinceDto Province { get; set; }        
    }
}
