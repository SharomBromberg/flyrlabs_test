public class Transport
{
    public string FlightCarrier { get; private set; }
    public string FlightNumber { get; private set; }

    public Transport(string flightCarrier, string flightNumber)
    {
        if (string.IsNullOrWhiteSpace(flightCarrier))
        {
            throw new ArgumentException("Flight carrier cannot be null or whitespace.", nameof(flightCarrier));
        }

        if (string.IsNullOrWhiteSpace(flightNumber))
        {
            throw new ArgumentException("Flight number cannot be null or whitespace.", nameof(flightNumber));
        }

        FlightCarrier = flightCarrier;
        FlightNumber = flightNumber;
    }
}