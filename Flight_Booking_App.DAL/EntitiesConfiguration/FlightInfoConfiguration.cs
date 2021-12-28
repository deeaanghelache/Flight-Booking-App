using Flight_Booking_App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Flight_Booking_App.DAL.EntitiesConfiguration
{
    public class FlightInfoConfiguration : IEntityTypeConfiguration<FlightInfo>
    {

        public void Configure(EntityTypeBuilder<FlightInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.DepartureDate)
                .HasColumnType("date")
                .IsRequired();
            
            builder.Property(p => p.ArrivalDate)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(p => p.Flight)
                .WithMany(p => p.FlightInfos)
                .HasForeignKey(p => p.FlightId);
        }
    }
}
