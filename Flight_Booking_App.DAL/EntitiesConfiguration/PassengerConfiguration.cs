using Flight_Booking_App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight_Booking_App.DAL.EntitiesConfiguration
{
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {

        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.FirstName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Nationality)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.TravelDocument)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.TravelDocumentNumber)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.TravelDocumentExpirationDate)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.User)
                .WithMany(p => p.Passengers)
                .HasForeignKey(p => p.UserId);

        }
    }
}



