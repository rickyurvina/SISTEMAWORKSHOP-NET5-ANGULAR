using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5.AspNet.Workshop.Infrastructure.Dtos
{
    public class PersonDto
    {
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public string FullName { get; set; }

        public virtual AddressDto Address { get; set; }
    }
}
