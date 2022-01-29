using Flight_Booking_App.BLL.Interfaces;
using Flight_Booking_App.DAL;
using Flight_Booking_App.DAL.Entities;
using Flight_Booking_App.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class FlightController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FlightController(AppDbContext context)
        {
            _context = context;
        }

        // Toate atributele din flight
        //public string DepartureAirport { get; set; }
        //public string ArrivalAirport { get; set; }
        //public int SeatsNumber { get; set; }
        //public string Airline { get; set; }

        // task -> se creeaza un proces de unde se apeleaza acest endpointul 
        // async -> pentru metoda respectiva se creeaza un proces separat (se deschide un thread separat 
        // si se ruleaza acel proces pe acest thread)
        [HttpPost("AddFlight")]
        [Authorize("Admin")]
        public async Task<IActionResult> AddFlight([FromBody] Flight flight)
        {
            // punem check-uri

            if (string.IsNullOrEmpty(flight.DepartureAirport)) {
                return BadRequest("Departure Airport is empty!");
            }

            if (string.IsNullOrEmpty(flight.ArrivalAirport)) {
                return BadRequest("Arrival Airport is empty!");
            }

            if (string.IsNullOrEmpty(flight.SeatsNumber.ToString())) {
                return BadRequest("Seats Number is empty");
            }

            if (string.IsNullOrEmpty(flight.Airline)) {
                return BadRequest("Airline is empty!");
            }

            // adaug zborul la DbSet-ul Flights
            // await ne spune ca asteptam rularea thread-ului
            await _context.Flights.AddAsync(flight);

            // salvam zborul in baza de date
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // oricine vrea sa vada toate zborurile disponibile in bd
        [HttpGet("GetAllFlights")]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _context.Flights.ToListAsync();
            return Ok(flights);
        }

        [HttpGet("GetAllDestinations")]
        public async Task<IActionResult> GetAllDestinations()
        {
            var destinations = await _context
                .Flights
                .Select(x => x.ArrivalAirport)
                .Distinct()
                .ToListAsync();

            return Ok(destinations);
        }

        [HttpGet("GetAllDepartures")]
        public async Task<IActionResult> GetAllDepartures()
        {
            var departures = await _context
                .Flights
                .Select(x => x.DepartureAirport)
                .Distinct()
                .ToListAsync();

            return Ok(departures);
        }

        // vrem sa afisam o lista cu toate zborurile dintre departure airport si arrival airport 
        [HttpGet("GetFlightDepArr/{departure}/{arrival}")]
        public async Task<IActionResult> GetFlightDepArr([FromRoute] string departureAirport, string arrivalAirport)
        {

            if (string.IsNullOrEmpty(departureAirport))
            {
                return BadRequest("Departure Airport is empty!");
            }

            if (string.IsNullOrEmpty(arrivalAirport))
            {
                return BadRequest("Arrival Airport is empty!");
            }

            var flights = await _context
                .Flights
                .Where(x => x.DepartureAirport == departureAirport)
                .Where(x => x.ArrivalAirport == arrivalAirport)
                .Select(x => new { Airline = x.Airline })
                .ToListAsync();
            return Ok(flights);
        }

        [HttpGet("GetFlight/{idFlight}")]
        public async Task<IActionResult> GetFlight([FromRoute] int idFlight)
        {
            if (idFlight == 0)
            {
                return BadRequest("Id Flight is 0!");
            }

            // async -> 2 sau mai multe operatii ruleaza in paralel si nu se blocheaza una pe cealalta
            var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == idFlight);

            return Ok(flight);
        }

        // pentru un anumit zbor, vreau sa afisez informatiile din Flight si InfoFlight
        [HttpGet("GetFlightInfo/{idFlight}")]
        public async Task<IActionResult> GetFlightInfo([FromRoute] int idFlight)
        {
            if (idFlight == 0)
            {
                return BadRequest("Id Flight is 0!");
            }

            try
            {
                var flights = _context.Flights;

                // in join: ii spunem cu cine facem join-ul (cu flights), cu cheia din flights si cheia din flight

                var flightInfos = _context.FlightInfos
                    .Join(flights, b => b.FlightId, a => a.Id, (b, a) => new
                {
                    b.DepartureDate,
                    b.ArrivalDate,
                    a.Id
                }).Where(x => x.Id == idFlight)
                  .ToList();

                return Ok(flightInfos);
            }
            catch (Exception exception)
            {
                return BadRequest(exception);
            }
        }

        [HttpDelete("DeleteFlight/{idFlight}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteFlight([FromRoute] int idFlight)
        {
            if (idFlight == 0)
            {
                return BadRequest("Id Flight is 0!");
            }

            var flight = await _context.Flights.FirstOrDefaultAsync(x => x.Id == idFlight);

            _context.Remove(flight);

            await _context.SaveChangesAsync();
            return Ok();

            //var flights = await _context
            //    .Flights
            //    .Select(x => new { Id = x.Id })
            //    .ToListAsync();

            //foreach(var flig in flights)
            //{
            //    Console.WriteLine(flig);
            //}

            //var flightInfos = _context.FlightInfos
            //        .Join(_context.Flights, b => b.FlightId, a => a.Id, (b, a) => new
            //        {
            //            IdInfo = b.Id,
            //            IdFlight = b.FlightId,
            //            b.ArrivalDate,
            //            b.DepartureDate
            //        }).Where(x => x.IdFlight == idFlight)
            //        .ToList();

            //flightInfos.ToList().ForEach(x => Console.WriteLine($"Flight info cu id {x.IdInfo}, pentru flight cu id {x.IdFlight}."));

            //foreach (var flightInfo in flightInfos)
            //{
            //    var info = _context.FlightInfos.First(p => p.Id == flightInfo.IdInfo);
            //    _context.Remove(info);
            //    _context.SaveChanges();
            //}

            //// flightInfos.ToList().ForEach(x => _context.FlightInfos.Remove());

            //var bookings = _context.Bookings
            //    .Join(_context.Flights, b => b.FlightId, a => a.Id, (b, a) => new
            //    {
            //        b.Id,
            //        b.FlightId
            //    }).Where(x => x.FlightId == idFlight);

            //foreach (var booking in bookings)
            //{
            //    var book = _context.Bookings.First(p => p.Id == booking.Id);
            //    _context.Remove(book);
            //    _context.SaveChanges();
            //}

            //bookings.ToList().ForEach(x => _context.Remove(x));
        }

        [HttpPut("UpdateFligh/{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> UpdateFlight([FromRoute] int id, [FromBody] Flight flight)
        {
            if (id == 0)
            {
                return BadRequest("Id Booking is 0!");
            }

            var _flight = await _context
                .Flights
                .FirstOrDefaultAsync(x => x.Id == id);

            if (_flight != null)
            {
                _flight.Airline = flight.Airline;
                _flight.ArrivalAirport = flight.ArrivalAirport;
                _flight.DepartureAirport = flight.DepartureAirport;
                _flight.SeatsNumber = flight.SeatsNumber;

                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
