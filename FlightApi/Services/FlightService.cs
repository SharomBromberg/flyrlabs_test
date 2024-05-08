using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MyFlightApi.Services;
using Newtonsoft.Json;

public class FlightService : IFlightService
{
    private List<Journey> _journeys;

    public FlightService()
    {
        _journeys = LoadJourneysFromDataSource().Result;
    }

    public async Task<List<Journey>> GetOneWayFlights(string origin, string destination)
    {
        return await Task.Run(() => _journeys.Where(j => j.Origin == origin && j.Destination == destination).ToList());
    }

    public async Task<List<Journey>> GetRoundTripFlights(string origin, string destination)
    {
        return await Task.Run(() => _journeys.Where(j => j.Origin == origin && j.Destination == destination || j.Origin == destination && j.Destination == origin).ToList());
    }

    private async Task<List<Journey>> LoadJourneysFromDataSource()
    {
        var json = await File.ReadAllTextAsync("/Data/markets.json");
        var journeys = JsonConvert.DeserializeObject<List<Journey>>(json);
        return journeys ?? new List<Journey>();
    }
}