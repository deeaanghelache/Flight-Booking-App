using System;
using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_App.DAL.Entities
{
    public class Payment
    {
        public Payment()
        {
        }

        [Key]
        public int Id { get; set; }

        public decimal Total { get; set; }
        public string Status { get; set; } // not required, default pending

        public int BookingId { get; set; } // foreign key
        public virtual Booking Booking { get; set; }
    }
}
