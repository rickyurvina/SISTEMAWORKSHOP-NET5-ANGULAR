﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities
{
    public partial class Address
    {
        public Address()
        {
            People = new HashSet<Person>();
        }

        public int AddressId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }

        public virtual Department Department { get; set; }
        public virtual District District { get; set; }
        public virtual Province Province { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}