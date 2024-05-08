public class Journey
{
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public decimal Price { get; private set; }
    public List<Flight> Flights { get; private set; }

    public Journey(string origin, string destination, decimal price, List<Flight> flights)
    {
        if (string.IsNullOrWhiteSpace(origin))
        {
            throw new ArgumentException("Origin cannot be null or whitespace.", nameof(origin));
        }

        if (string.IsNullOrWhiteSpace(destination))
        {
            throw new ArgumentException("Destination cannot be null or whitespace.", nameof(destination));
        }

        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative.", nameof(price));
        }

        if (flights == null || !flights.Any())
        {
            throw new ArgumentException("Flights cannot be null or empty.", nameof(flights));
        }

        Origin = origin;
        Destination = destination;
        Price = price;
        Flights = flights;
    }
}
