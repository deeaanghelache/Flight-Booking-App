using System;
using Flight_Booking_App.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Flight_Booking_App.DAL.EntitiesConfiguration;

namespace Flight_Booking_App.DAL
{
    public class AppDbContext : IdentityDbContext<
                                User,
                                Role,
                                int,
                                IdentityUserClaim<int>,
                                UserRole,
                                IdentityUserLogin<int>,
                                IdentityRoleClaim<int>,
                                IdentityUserToken<int>>
    { 

    public AppDbContext()
    {
    }

    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<BoardingPass> BoardingPasses { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<FlightInfo> FlightInfos { get; set; }
    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentConfiguration());
        modelBuilder.ApplyConfiguration(new PassengerConfiguration());
        modelBuilder.ApplyConfiguration(new BoardingPassConfiguration());
        modelBuilder.ApplyConfiguration(new FlightConfiguration());
        modelBuilder.ApplyConfiguration(new FlightInfoConfiguration());


        }

    }
}
