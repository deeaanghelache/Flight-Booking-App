using Flight_Booking_App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight_Booking_App.DAL.EntitiesConfiguration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {

        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DepartureAirport)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.ArrivalAirport)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.SeatsNumber)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.Airline)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}
