﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities
{
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int WorkshopId { get; set; }
        public int EnrolledPersonId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int EnrollmentStateId { get; set; }

        public virtual Person EnrolledPerson { get; set; }
        public virtual EnrollmentState EnrollmentState { get; set; }
        public virtual Workshop Workshop { get; set; }
    }
}