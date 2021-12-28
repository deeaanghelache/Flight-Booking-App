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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Total)
                .HasColumnType("decimal(4,2)")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100)
                .HasDefaultValue("Pending");

            builder.HasOne(p => p.Booking)
                .WithOne(p => p.Payment)
                .HasForeignKey<Payment>(p => p.BookingId);
        }
    }
}
