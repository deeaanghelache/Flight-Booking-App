using Flight_Booking_App.BLL.Interfaces;
using Flight_Booking_App.DAL;
using Flight_Booking_App.DAL.Entities;
using Flight_Booking_App.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Flight_Booking_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IAuthenticationManager _authManager;
        private readonly UserManager<User> _userManager;

        public UserAuthenticationController(AppDbContext context, IAuthenticationManager authManager, UserManager<User> userManager)
        {
            _context = context;
            _authManager = authManager;
            _userManager = userManager;
        }

        // endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var result = await _authManager.Register(model);

            if (result)
                return Ok("Registered");
            else return BadRequest("Not registered");
        }

        // endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _authManager.Login(model);

            return Ok(result);
        }

        //[HttpPost("refresh")]
        //public async Task<IActionResult> Refresh(RefreshModel model)
        //{
        //    var result = await _authManager.Refresh(model);

        //    return Ok(result);
        //}

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            // getUsersInRoleAsync returneaza o lista de useri (care au rolul user)
            var users = await _userManager.GetUsersInRoleAsync("User");

            return Ok(users);
        }

        [HttpGet("getCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            //var id = _userManager.GetUserId(User);
            //var UserId = Int32.Parse(id);

            //var UserIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var UserId = Int32.Parse(UserIdString);

            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            //var userName = User.FindFirstValue(ClaimTypes.Name); // will give the user's userName

            //var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email

            var userEmail = User.FindFirst(ClaimTypes.Email).Value;

            Console.Write(userEmail);

            return Ok(userEmail);
        }

        [HttpGet("getCurrentUserId/{username}")]
        public async Task<IActionResult> GetCurrentUserId([FromRoute] string username)
        {
            //var user = _userManager.FindByEmailAsync(username);
            //var userId = _userManager.GetUserIdAsync(user);
            //return Ok(userId);
            Console.WriteLine(username);
            var users = await _userManager.GetUsersInRoleAsync("User");

            foreach (var user in users)
            {
                var email = user.Email;
                Console.WriteLine(email);
                if (email == username)
                {
                    Console.WriteLine(user.Id);
                    return Ok(user.Id);
                }
            }

            return BadRequest("No Id");
        }
    }
}
