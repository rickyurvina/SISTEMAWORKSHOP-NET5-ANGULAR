﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities
{
    public partial class EnrollmentState
    {
        public EnrollmentState()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int EnrollmentStateId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}