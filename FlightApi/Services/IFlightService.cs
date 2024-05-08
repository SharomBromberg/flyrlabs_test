namespace MyFlightApi.Services
{
    public interface IFlightService
    {
        Task<List<Journey>> GetOneWayFlights(string origin, string destination);
        Task<List<Journey>> GetRoundTripFlights(string origin, string destination);
    }
}