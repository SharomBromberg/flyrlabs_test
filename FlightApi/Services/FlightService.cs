using FlightAPI.Interfaces;
using FlightAPI.Models;
using Newtonsoft.Json;
using RestSharp;//Libreria para realizar el intercambio de moneda

public class FlightService : IFlightService
{
    //creación de la ruta que lista los vuelos en formato json
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "markets.json");
    private List<Flight> _flights; //lista para almacenar los datos de los vuelos

    public FlightService()
    {
        _flights = new List<Flight>();
        var json = File.ReadAllText(_filePath);// Lee el archivo JSON y lo almacena en la variable json
        //Luego se deserializa el JSON a una lista de objetos Flight y se almacena en la variable _flights
        _flights = JsonConvert.DeserializeObject<List<Flight>>(json) ?? new List<Flight>(); // Nos aseguramos de que _flights nunca sea null
    }
    //Método para obtener todos los vuelos
    public Task<IEnumerable<Flight>> GetAllFlights()
    {
        return Task.FromResult(_flights.AsEnumerable());
    }
    //Método para convertir la moneda
    private async Task<double> ConvertCurrency(string from, string to, double amount)
    {
        // Si la moneda de destino es USD, devuelve el monto original, así no se hace la conversión desde la API
        if (to.ToUpper() == "USD")
        {
            return amount;
        }


        // Se crea un cliente de RestSharp para hacer la solicitud a la API de conversión de moneda
        var client = new RestClient($"https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}");

        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddHeader("apikey", "Kz9TmboV4gPfHOshSzjTBKmPbNquVl8l");
        request.Timeout = -1;

        var response = await client.ExecuteAsync(request);
        if (response.Content == null)
        {
            throw new Exception("La respuesta de la API de conversión de moneda está vacía.");
        }

        //Deserialización de la respuesta de la API de conversión de moneda a un objeto dinámico
        //y se extrae el resultado de la conversión
        var content = JsonConvert.DeserializeObject<dynamic>(response.Content);
        if (content == null)
        {
            throw new Exception("No se pudo deserializar la respuesta de la API de conversión de moneda.");
        }

        if (content.result == null)
        {
            throw new Exception("La respuesta de la API de conversión de moneda no contiene un resultado.");
        }

        return Convert.ToDouble(content.result);
    }

    // Método para obtener los vuelos de ida de un origen a un destino, incluyendo vuelos con escalas
    public async Task<IEnumerable<Flight>> GetOneWayFlights(string origin, string destination, string currency)
    {
        var oneWayFlights = _flights.Where(f => f.Origin == origin && f.Destination == destination).ToList();
        foreach (var flight in oneWayFlights)
        {
            flight.Price = await ConvertCurrency("USD", currency, flight.Price);
        }

        var flightsWithStops = new List<Flight>();
        foreach (var flight in _flights.Where(f => f.Origin == origin))
        {
            var route = new List<Flight> { flight };
            var currentDestination = flight.Destination;
            while (currentDestination != destination)
            {
                var nextFlight = _flights.FirstOrDefault(f => f.Origin == currentDestination && f.Destination == destination);
                if (nextFlight == null)
                    break;
                route.Add(nextFlight);
                currentDestination = nextFlight.Destination;
            }
            if (route.Count > 1)
            {
                flightsWithStops.AddRange(route.Skip(1)); // salta el vuelo directo 
            }
        }

        return oneWayFlights.Concat(flightsWithStops);
    }

    // Método para obtener los vuelos de ida y vuelta entre un origen y un destino, incluyendo vuelos con escalas
    public async Task<IEnumerable<Flight>> GetRoundTripFlights(string origin, string destination, string currency)
    {
        var roundTripFlights = _flights.Where(f =>
            (f.Origin == origin && f.Destination == destination) ||
            (f.Origin == destination && f.Destination == origin)).ToList();

        foreach (var flight in roundTripFlights)
        {
            flight.Price = await ConvertCurrency("USD", currency, flight.Price);
        }

        return roundTripFlights;
    }
    public async Task<IEnumerable<string>> GetAllCurrencies()
    {
        var client = new RestClient("https://api.apilayer.com/exchangerates_data/all_currencies");

        var request = new RestRequest();
        request.Method = Method.Get;
        request.AddHeader("apikey", "Kz9TmboV4gPfHOshSzjTBKmPbNquVl8l");
        request.Timeout = -1;

        var response = await client.ExecuteAsync(request);
        if (response.Content == null)
        {
            throw new Exception("La respuesta de la API de monedas está vacía.");
        }

        var content = JsonConvert.DeserializeObject<dynamic>(response.Content);
        if (content == null)
        {
            throw new Exception("No se pudo deserializar la respuesta de la API de monedas.");
        }

        if (content.currencies == null)
        {
            throw new Exception("La respuesta de la API de monedas no contiene un resultado.");
        }

        return content.currencies.ToObject<IEnumerable<string>>();
    }

}