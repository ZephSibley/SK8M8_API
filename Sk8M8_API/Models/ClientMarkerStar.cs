namespace Sk8M8_API.Models
{
    public class ClientMarkerStar
    {
        public long ClientId { get; set; }
        public Client Client { get; set; }
        public long MapMarkerId { get; set; }
        public MapMarker MapMarker { get; set; }
    }
}