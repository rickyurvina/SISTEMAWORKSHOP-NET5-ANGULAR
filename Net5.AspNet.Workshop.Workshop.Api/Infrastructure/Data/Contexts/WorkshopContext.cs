﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts.Configurations;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using System;

#nullable disable

namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts
{
    public partial class WorkshopContext : DbContext
    {
        public WorkshopContext()
        {
        }

        public WorkshopContext(DbContextOptions<WorkshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<EnrollmentState> EnrollmentStates { get; set; }
        public virtual DbSet<FileDatum> FileData { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Entities.Workshop> Workshops { get; set; }
        public virtual DbSet<WorkshopState> WorkshopStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new Configurations.CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EnrollmentConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EnrollmentStateConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FileDatumConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PersonConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.WorkshopConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.WorkshopStateConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
