﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using System;


namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts.Configurations
{
    public partial class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> entity)
        {
            entity.ToTable("District", "Workshop");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Province)
                .WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DistrictProvince");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<District> entity);
    }
}