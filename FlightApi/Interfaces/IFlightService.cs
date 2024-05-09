using FlightAPI.Models;
namespace FlightAPI.Interfaces;

public interface IFlightService
{
    Task<IEnumerable<Flight>> GetAllFlights();
    Task<IEnumerable<Flight>> GetOneWayFlights(string origin, string destination, string currency);
    Task<IEnumerable<Flight>> GetRoundTripFlights(string origin, string destination, string currency);

}