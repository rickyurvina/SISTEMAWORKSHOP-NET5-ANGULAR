﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Net5.AspNet.Workshop.IdentityProvider.Infrastructure.Data.Security.Entities
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        public string IdentificationNumber { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}