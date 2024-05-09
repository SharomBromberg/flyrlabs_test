namespace FlightAPI.Core.Entities
{
    public class TransportEntity
    {
        public int Id { get; set; }
        public required string FlightCarrier { get; set; }
        public required string FlightNumber { get; set; }

        public required List<FlightEntity> Flights { get; set; }
    }

}