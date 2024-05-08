
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFlightApi.Services;

[ApiController]
[Route("[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet("OneWay")]
    public async Task<IActionResult> GetOneWayFlights(string origin, string destination)
    {
        var flights = await _flightService.GetOneWayFlights(origin, destination);
        return Ok(flights);
    }

    [HttpGet("RoundTrip")]
    public async Task<IActionResult> GetRoundTripFlights(string origin, string destination)
    {
        var flights = await _flightService.GetRoundTripFlights(origin, destination);
        return Ok(flights);
    }
}