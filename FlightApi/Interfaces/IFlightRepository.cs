using FlightAPI.Core.Entities;
namespace FlightAPI.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<FlightEntity>> GetAllFlights();
    Task<FlightEntity> GetFlightById(int id);
    Task AddFlight(FlightEntity flight);
    Task UpdateFlight(FlightEntity flight);
    Task DeleteFlight(int id);
}
