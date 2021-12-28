using System;
using System.ComponentModel.DataAnnotations;
using Flight_Booking_App.DAL.Entities;

namespace Flight_Booking_App.DAL.Entities
{
    public class BoardingPass
    {
        public BoardingPass()
        {
        }

    [Key]
    public int Id { get; set; }

    public string SeatNumber { get; set; }
    public DateTime BoardingTime { get; set; }
    public string Gate { get; set; }

    public int? PassengerId { get; set; }
    // public int FlightId { get; set; }
    public int? BookingId { get; set; }

    public virtual Passenger Passenger { get; set; }
    // public virtual Flight Flight { get; set; }
    public virtual Booking Booking { get; set; }

    }
}
