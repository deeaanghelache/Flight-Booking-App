using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flight_Booking_App.DAL.Entities
{
    public class Passenger
    {
        public Passenger()
        {
        }

        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string TravelDocument { get; set; } // type of travel document (passport, identity card)
        public string TravelDocumentNumber { get; set; }
        public DateTime TravelDocumentExpirationDate { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        // a passenger can have multiple boarding passes
        public virtual ICollection<BoardingPass> BoardingPasses { get; set; }

    }
}
