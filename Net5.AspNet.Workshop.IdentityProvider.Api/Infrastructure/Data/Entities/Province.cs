﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities
{
    public partial class Province
    {
        public Province()
        {
            Addresses = new HashSet<Address>();
            Districts = new HashSet<District>();
        }

        public int ProvinceId { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}