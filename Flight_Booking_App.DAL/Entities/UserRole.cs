using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.Entities
{
    public class UserRole : IdentityUserRole<int>
    {
        public UserRole()
        {
        }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}