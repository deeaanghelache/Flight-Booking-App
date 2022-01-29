using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.Models
{
    public class PassengerModel
    {
        public PassengerModel()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string TravelDocument { get; set; } // type of travel document (passport, identity card)
        public string TravelDocumentNumber { get; set; }
        public DateTime TravelDocumentExpirationDate { get; set; }

        public string Username { get; set; }
        public int? UserId{ get; set; }
    }
}
