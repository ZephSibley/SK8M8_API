namespace Sk8M8_API.Models
{
    public class ClientMarker : BaseEntity
    {
        public Client User { get; set; }
        public MapMarker MapMarker { get; set; }
    }
}
