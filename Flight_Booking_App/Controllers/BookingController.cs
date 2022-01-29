using Flight_Booking_App.BLL.Interfaces;
using Flight_Booking_App.DAL;
using Flight_Booking_App.DAL.Entities;
using Flight_Booking_App.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Flight_Booking_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public BookingController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Toate atributele din Booking
        //public DateTime DepartureDate { get; set; }
        //public DateTime ArrivalDate { get; set; }
        //public string DepartureAirport { get; set; }
        //public string ArrivalAirport { get; set; }
        //public string Class { get; set; } // default economy, not required
        //public int NrOfPassengers { get; set; } // default 1, required
        //public string OnlyDirect { get; set; } // default false, not required

        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking([FromBody] Booking booking)
        {
            //if (booking.DepartureDate == default(DateTime))
            //{
            //    return BadRequest("Departure Date is empty");
            //}

            //if (booking.ArrivalDate == default(DateTime))
            //{
            //    return BadRequest("Arrival Date is empty");
            //}

            //if (string.IsNullOrEmpty(booking.DepartureAirport))
            //{
            //    return BadRequest("Departure Airport is empty!");
            //}

            //if (string.IsNullOrEmpty(booking.ArrivalAirport))
            //{
            //    return BadRequest("Arrival Airport is empty!");
            //}

            //if (string.IsNullOrEmpty(booking.Class))
            //{
            //    return BadRequest("Class is empty!");
            //}

            //if (string.IsNullOrEmpty(booking.NrOfPassengers.ToString()))
            //{
            //    return BadRequest("Number of Passengers is empty!");
            //}

            //if (string.IsNullOrEmpty(booking.OnlyDirect))
            //{
            //    return BadRequest("Only Direct is empty!");
            //}

            //var id = _userManager.GetUserId(User);
            //var UserId = Int32.Parse(id);

            ////var UserIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ////var UserId = Int32.Parse(UserIdString);
            //booking.UserId = UserId;

            var idFlight = await _context
                .Flights
                .Where(x => x.DepartureAirport == booking.DepartureAirport)
                .Where(x => x.ArrivalAirport == booking.ArrivalAirport)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            //var User = _userManager.FindByEmailAsync(booking.username);
            //var idUser = 

            booking.FlightId = idFlight;

            Console.WriteLine(idFlight);
            Console.WriteLine(booking);

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("GetAllBookings/{idUser}")]
        public async Task<IActionResult> GetAllBookingsForCurrentUser([FromRoute] int idUser)
        {
            // get all the bookings for current user, sorted desc by departure date

            if (idUser == 0)
            {
                return BadRequest("Id User is 0!");
            }

            var bookingsForCurrentUser = await _context
            .Bookings
            .Where(book => book.UserId == idUser)
            .OrderByDescending(book => book.DepartureDate)
            .ToListAsync();

            return Ok(bookingsForCurrentUser);
        }

        [HttpPut("UpdateBooking/{idBooking}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateBooking(int idBooking, [FromBody] Booking booking)
        {
            if (idBooking == 0)
            {
                return BadRequest("Id Booking is 0!");
            }

            var _booking = await _context
                .Bookings
                .FirstOrDefaultAsync(book => book.Id == idBooking);

            if (_booking != null)
            {
                _booking.ArrivalAirport = booking.ArrivalAirport;
                _booking.DepartureAirport = booking.DepartureAirport;
                _booking.DepartureDate = booking.DepartureDate;
                _booking.ArrivalDate = booking.ArrivalDate;
                _booking.Class = booking.Class;
                _booking.NrOfPassengers = booking.NrOfPassengers;
                _booking.OnlyDirect = booking.OnlyDirect;

                _context.SaveChanges();
            }

            return Ok();
        }

        [HttpDelete("DeleteBooking/{idBooking}")]
        [Authorize("User")]
        public async Task<IActionResult> DeleteBooking(int idBooking)
        {
            if (idBooking == 0)
            {
                return BadRequest("Id Booking is 0!");
            }

            var booking = await _context
                .Bookings
                .FirstOrDefaultAsync(book => book.Id == idBooking);

            _context.Remove(booking);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
