using System;
using System.Threading.Tasks;
using Flight_Booking_App.DAL;
using Flight_Booking_App.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;
using Flight_Booking_App.DAL.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Flight_Booking_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;

        public PassengerController(AppDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("AddPassenger")]
        [Authorize("User")]
        public async Task<IActionResult> AddPassenger([FromBody] Passenger passenger)
        {
            // check-uri
            if (string.IsNullOrEmpty(passenger.FirstName)) {
                return BadRequest("First Name is null");
            }

            if (string.IsNullOrEmpty(passenger.LastName)) {
                return BadRequest("Last Name is empty");
            }

            // ???
            if (passenger.DateOfBirth == default(DateTime)) {
                return BadRequest("Date of birth is empty");
            }

            if (string.IsNullOrEmpty(passenger.Nationality)) {
                return BadRequest("Nationality is empty");
            }

            if (string.IsNullOrEmpty(passenger.TravelDocument)) {
                return BadRequest("Travel Document is empty");
            }

            if (string.IsNullOrEmpty(passenger.TravelDocumentNumber)) {
                return BadRequest("Travel Document Number is empty");
            }

            // ???
            if (passenger.TravelDocumentExpirationDate == default(DateTime)) {
                return BadRequest("Travel Document Expiration Date is empty");
            }

            // vezi ce faci cu user id ???

            //var UserId = User.Identity.GetUserId();

            //ClaimsPrincipal currentUser = this.User;
            //var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var UserId = Int32.Parse(currentUserID);

            //var id = _userManager.GetUserId(User);
            //var UserId = Int32.Parse(id);

            //var UserIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var UserId = Int32.Parse(UserIdString);
            //passenger.UserId = UserId;

            //if (string.IsNullOrEmpty(passenger.Username))
            //{
            //    return BadRequest("Username is null");
            //}

            //var User = _context.Users.SingleOrDefault(i => i.UserName == passenger.Username);

            // added passenger to Passengers
            await _context.Passengers.AddAsync(passenger);

            // now context can save the changes and add the passenger in the database
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //[HttpGet("GetPassenger/{id}")]
        //public async Task<IActionResult> GetPassenger ([FromRoute] int idPassenger)
        //{
        //    if (idPassenger == 0)
        //    {
        //        return BadRequest("IdStudent cannot be 0");
        //    }

        //    var passenger = await _context.Passengers.FirstOrDefaultAsync(x => x.Id == idPassenger);

        //    return Ok(passenger);
        //}

        [HttpDelete("DeletePassenger/{id}")]
        [Authorize("User")]
        public async Task<IActionResult> DeletePassenger([FromRoute] int idPassenger)
        {
            if (idPassenger == 0)
            {
                return BadRequest("Id Passenger is 0!");
            }

            var passenger = await _context.Passengers.FirstOrDefaultAsync(x => x.Id == idPassenger);

            _context.Remove(passenger);

            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet("GetAllPassengers/{username}")]
        public async Task<IActionResult> GetAllPassengers([FromRoute] string username)
        {
            var user = await _userManager.FindByEmailAsync(username);

            var passengers = _context
                .Passengers
                .Include(x => x.User)
                .Where(x => x.User.Id == user.Id)
                .OrderBy(x => x.LastName)
                .ToListAsync();

            return Ok(passengers);
        }

        [HttpGet("GetAllPass")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetAllPass()
        {
            var passengers = await _context.Passengers.ToListAsync();
            return Ok(passengers);
        }
    }
}
