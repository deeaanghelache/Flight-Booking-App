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
    public class BoardingPassConfiguration : IEntityTypeConfiguration<BoardingPass>
    {
        public void Configure(EntityTypeBuilder<BoardingPass> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.SeatNumber)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(p => p.BoardingTime)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Gate)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10)
                .IsRequired();

            builder.HasOne(p => p.Passenger)
                .WithMany(p => p.BoardingPasses)
                .HasForeignKey(p => p.PassengerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Booking)
                .WithMany(p => p.BoardingPasses)
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
