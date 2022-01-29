using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
