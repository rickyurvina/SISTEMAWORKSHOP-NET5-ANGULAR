﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts;
using Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Entities;
using System;


namespace Net5.AspNet.Workshop.IdentityProvider.Api.Infrastructure.Data.Contexts.Configurations
{
    public partial class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
    {
        public void Configure(EntityTypeBuilder<UserLogin> entity)
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.ToTable("UserLogins", "Security");

            entity.HasIndex(e => e.UserId, "IX_UserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);

            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.Property(e => e.UserId).IsRequired();

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserLogins)
                .HasForeignKey(d => d.UserId);

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<UserLogin> entity);
    }
}