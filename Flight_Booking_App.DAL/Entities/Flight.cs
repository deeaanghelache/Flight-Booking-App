using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Flight_Booking_App.DAL.Entities;

namespace Flight_Booking_App.DAL.Entities
{
    public class Flight
    {
        public Flight()
        {
        }

        [Key]
        public int Id { get; set; }

        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public int SeatsNumber { get; set; }
        public string Airline { get; set; }

        public virtual ICollection<FlightInfo> FlightInfos { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
