using FlightAPI.Models;
using Microsoft.EntityFrameworkCore;

public class FlightContext : DbContext
{
    public DbSet<Journey> Journeys { get; set; }
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Transport> Transports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=flights.db");
    }
}
