namespace Sk8M8_API.Models
{
    public class MarkerCategory : BaseEntity
    {
        public MapMarker MapMarker { get; set; }
        public LocationType LocationType { get; set; }
    }
}
