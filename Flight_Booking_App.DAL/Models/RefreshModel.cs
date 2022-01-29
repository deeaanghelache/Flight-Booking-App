using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Booking_App.DAL.Models
{
    public class RefreshModel
    {
        public RefreshModel()
        {
        }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
