using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flight_Booking_App.DAL.Entities;

namespace Flight_Booking_App.DAL.Entities
{
    public class FlightInfo
    {
        public FlightInfo()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

    }
}
