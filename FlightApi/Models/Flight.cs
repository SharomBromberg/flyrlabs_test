public class Flight
{
    public string FlightNumber { get; private set; }
    public string DepartureAirport { get; private set; }
    public string ArrivalAirport { get; private set; }
    public DateTime DepartureTime { get; private set; }
    public DateTime ArrivalTime { get; private set; }
    public Transport Transport { get; private set; }

    public Flight(string flightNumber, string departureAirport, string arrivalAirport, DateTime departureTime, DateTime arrivalTime, Transport transport)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
        {
            throw new ArgumentException("Flight number cannot be null or whitespace.", nameof(flightNumber));
        }

        if (string.IsNullOrWhiteSpace(departureAirport))
        {
            throw new ArgumentException("Departure airport cannot be null or whitespace.", nameof(departureAirport));
        }

        if (string.IsNullOrWhiteSpace(arrivalAirport))
        {
            throw new ArgumentException("Arrival airport cannot be null or whitespace.", nameof(arrivalAirport));
        }

        if (departureTime >= arrivalTime)
        {
            throw new ArgumentException("Departure time must be earlier than arrival time.", nameof(departureTime));
        }

        if (transport == null)
        {
            throw new ArgumentException("Transport cannot be null.", nameof(transport));
        }

        FlightNumber = flightNumber;
        DepartureAirport = departureAirport;
        ArrivalAirport = arrivalAirport;
        DepartureTime = departureTime;
        ArrivalTime = arrivalTime;
        Transport = transport;
    }
}
