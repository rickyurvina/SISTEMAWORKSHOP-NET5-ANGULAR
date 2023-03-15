﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities
{
    public partial class Workshop
    {
        public Workshop()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int WorkshopId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int InstructorPersonId { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public int WorkshopStateId { get; set; }
        public int CoverFileDataId { get; set; }
        public int AgendaFileDataId { get; set; }

        public virtual FileDatum AgendaFileData { get; set; }
        public virtual Category Category { get; set; }
        public virtual FileDatum CoverFileData { get; set; }
        public virtual Person InstructorPerson { get; set; }
        public virtual WorkshopState WorkshopState { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}