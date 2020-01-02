using GeoAPI.Geometries;

namespace Sk8M8_API.Models
{
    public class MapMarker : BaseEntity
    {
        public string Name { get; set; }
        public string LocationCategory { get; set; }
        public IPoint Point { get; set; }
        public Media Video { get; set; }
        public Client Creator { get; set; }
    }
}
