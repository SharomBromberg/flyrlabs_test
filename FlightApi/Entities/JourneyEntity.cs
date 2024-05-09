namespace FlightAPI.Core.Entities
{
    using FlightAPI.Core.Entities;

    public class JourneyEntity
    {
        public int Id { get; set; }
        public int FlightId { get; set; } // Esta propiedad representa la clave foránea a la tabla Flight
        public required FlightEntity Flight { get; set; } // Esta propiedad representa la relación con la entidad Flight
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public double Price { get; set; }
    }
}
