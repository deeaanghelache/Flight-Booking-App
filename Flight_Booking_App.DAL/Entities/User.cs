using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flight_Booking_App.DAL.Entities;

namespace Flight_Booking_App.DAL.Entities
{
    public class User : IdentityUser<int>
    {
        public User()
        {
        }
        public string RefreshToken { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}