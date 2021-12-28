using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.Entities
{
    public class Role : IdentityRole<int>
    {
        public Role()
        {
        }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}