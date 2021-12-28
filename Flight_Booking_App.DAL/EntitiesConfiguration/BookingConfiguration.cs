using Flight_Booking_App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.EntitiesConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DepartureDate)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(p => p.ArrivalDate)
                .HasColumnType("Date")
                .IsRequired();

            builder.Property(p => p.DepartureAirport)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArrivalAirport)
               .HasColumnType("nvarchar(100)")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.Class)
                .HasColumnType("nvarchar(50)")
                .HasMaxLength(50)
                .HasDefaultValue("economy");

            builder.Property(p => p.NrOfPassengers)
                .HasColumnType("int")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(p => p.OnlyDirect)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10)
                .HasDefaultValue("false");

            builder.HasOne(p => p.User)
                .WithMany(p => p.Bookings)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Flight)
                .WithMany(p => p.Bookings)
                .HasForeignKey(p => p.FlightId);


        }
    }
}