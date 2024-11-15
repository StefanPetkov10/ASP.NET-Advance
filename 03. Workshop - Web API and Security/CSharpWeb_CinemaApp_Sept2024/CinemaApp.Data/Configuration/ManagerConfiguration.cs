﻿using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static CinemaApp.Common.EntityValidationConstants.Manager;

namespace CinemaApp.Data.Configuration
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder
               .HasKey(m => m.Id);

            builder
                .Property(m => m.WorkPhoneNumber)
                .IsRequired()
                .HasMaxLength(PhoneNumberMaxLength);

            builder
                .Property(m => m.UserId)
                .IsRequired();

            builder
                .HasOne(m => m.User)
                .WithOne()
                .HasForeignKey<Manager>(m => m.UserId);
        }
    }
}
