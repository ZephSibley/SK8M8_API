using NetTopologySuite.Geometries;

namespace Sk8M8_API.Models
{
    public class Client : BaseEntity
    {
        public string Username { get; set; }
        public Point Geolocation { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }
    }
}
