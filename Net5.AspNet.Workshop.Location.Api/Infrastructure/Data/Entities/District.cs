﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.Location.Api.Infrastructure.Data.Entities
{
    public partial class District
    {
        public int DistrictId { get; set; }
        public string Description { get; set; }
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
    }
}