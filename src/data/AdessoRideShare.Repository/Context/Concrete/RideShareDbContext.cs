using AdessoRideShare.Repository.Context.Interface;
using AdessoRideShare.Repository.EntityModel.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdessoRideShare.Repository.Context.Concrete
{
    public class RideShareDbContext : DbContext,IDbContext
    {
        public RideShareDbContext(DbContextOptions<RideShareDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, Name="Izmir"},
                new Location { Id = 2, Name = "Canakkale" }
            );
            modelBuilder.Entity<Trip>().HasData(
                new Trip { Id = 1, FromId = 1, ToId = 2, Date = DateTime.UtcNow, MaxSeat = 30, Status=1 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id=1,Name="Bahar",Surname="Sezin"},
                new User { Id = 2, Name = "Pınar", Surname = "Golet" }
            );
            modelBuilder.Entity<TripUsers>().HasData(
                new TripUsers { Id = 1, TravelPlanId=1, UserId=2 , Status=1, SeatCount=3 },
                new TripUsers { Id = 2, TravelPlanId=1, UserId=1 , Status=1 , SeatCount=9}
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Trip> TravelPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Cities { get; set; }
        public DbSet<TripUsers> TravelPlanUsers { get; set; }

    }
}
