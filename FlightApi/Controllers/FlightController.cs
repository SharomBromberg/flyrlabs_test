using Microsoft.AspNetCore.Mvc;
using FlightAPI.Interfaces;
using FlightAPI.Models;
//capa de presentación

namespace FlightAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
  
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService; //inyección de dependencias
        public FlightController(IFlightService flightService) //constructor
        {
            _flightService = flightService;
        }

        //solicitudes get a Flight/Flights - Devuelve la lista de vuelos basada en los parametros que recibe     
        [HttpGet("Flights")]
        public async Task<IActionResult> GetFlights(string origin, string destination, string currency, string flightType)
        {
            //validación de parametros para llamar a los métodos de la capa de servicios
            IEnumerable<Flight> flights;
            if (flightType == "oneway")
            {
                flights = await _flightService.GetOneWayFlights(origin, destination, currency);
            }
            else if (flightType == "roundtrip")
            {
                flights = await _flightService.GetRoundTripFlights(origin, destination, currency);
            }
            else
            {
                return BadRequest("Invalid flight type");//si el vuelo no es valido devolverá un error 400
            }

            Journey journey = new Journey();
            journey.Origin = origin;
            journey.Destination = destination;
            journey.Flights = new List<Flight>();

            double totalPrice = 0;
            string route = "";

            foreach (var flight in flights)
            {
                journey.Flights.Add(flight);
                totalPrice += flight.Price;
                route += $"{flight.Transport.FlightCarrier} {flight.Transport.FlightNumber} {flight.Origin}-{flight.Destination}, ";
            }

            journey.Price = totalPrice;
            route = route.TrimEnd(',', ' ');

            var response = new
            {
                Journey = journey,
                Route = route
            };

            return Ok(response);
        }

        //solicitudes GET a Flight/AllFlights - Devuelve la lista de todos los vuelos
        [HttpGet("AllFlights")]
        public async Task<IActionResult> GetAllFlights()
        {
            var flights = await _flightService.GetAllFlights();
            return Ok(flights);
        }
    }
}
