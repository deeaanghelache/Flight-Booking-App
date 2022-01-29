using System;
namespace Flight_Booking_App.DAL.Models
{
    public class BookingModel
    {
        public BookingModel()
        {
        }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Class { get; set; } // default economy, not required
        public int NrOfPassengers { get; set; } // default 1, required
        public string OnlyDirect { get; set; } // default false, not required

    }
}
