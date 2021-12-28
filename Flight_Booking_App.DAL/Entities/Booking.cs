using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flight_Booking_App.DAL.Entities;

namespace Flight_Booking_App.DAL.Entities
{
    public class Booking
    {
        public Booking()
        {
        }
        [Key]
        public int Id { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Class { get; set; } // default economy, not required
        public int NrOfPassengers { get; set; } // default 1, required
        public string OnlyDirect { get; set; } // default false, not required

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Payment Payment { get; set; }

        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

        public virtual ICollection<BoardingPass> BoardingPasses { get; set; }

    }
}