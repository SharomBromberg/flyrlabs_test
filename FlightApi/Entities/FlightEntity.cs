using System.Collections.ObjectModel;

namespace FlightAPI.Core.Entities
{
    public class FlightEntity
    {
        public int Id { get; set; }
        public int TransportId { get; set; } // Esta propiedad representa la clave foránea a la tabla Transport
        public required TransportEntity Transport { get; set; } // Esta propiedad representa la relación con la entidad Transport
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public double Price { get; set; }
        // Esta lista representa la relación uno a muchos con la entidad Journey
        public required List<JourneyEntity> Journeys { get; set; }
    }
}
