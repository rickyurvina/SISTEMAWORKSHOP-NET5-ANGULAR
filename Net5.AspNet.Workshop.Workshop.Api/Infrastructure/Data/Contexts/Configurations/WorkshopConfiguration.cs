﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Entities;
using System;


namespace Net5.AspNet.Workshop.Workshop.Api.Infrastructure.Data.Contexts.Configurations
{
    public partial class WorkshopConfiguration : IEntityTypeConfiguration<Entities.Workshop>
    {
        public void Configure(EntityTypeBuilder<Entities.Workshop> entity)
        {
            entity.ToTable("Workshop", "Workshop");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.AgendaFileData)
                .WithMany(p => p.WorkshopAgendaFileData)
                .HasForeignKey(d => d.AgendaFileDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopAgendaFileData");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Workshops)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopCategory");

            entity.HasOne(d => d.CoverFileData)
                .WithMany(p => p.WorkshopCoverFileData)
                .HasForeignKey(d => d.CoverFileDataId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopCoverFileData");

            entity.HasOne(d => d.InstructorPerson)
                .WithMany(p => p.Workshops)
                .HasForeignKey(d => d.InstructorPersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopInstructorPerson");

            entity.HasOne(d => d.WorkshopState)
                .WithMany(p => p.Workshops)
                .HasForeignKey(d => d.WorkshopStateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WorkshopWorkshopState");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Entities.Workshop> entity);
    }
}
