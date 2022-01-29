using System;

namespace Flight_Booking_App.BLL
{
    public class LoginResult
    {
        public LoginResult()
        {
        }

        public bool Success { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
