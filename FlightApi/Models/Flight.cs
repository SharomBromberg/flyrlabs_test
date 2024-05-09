//capa de dominio

namespace FlightAPI.Models
{
    

    public class Flight
    {
        public required Transport Transport { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public double Price { get; set; }
 
    }
}
