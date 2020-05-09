using System.Collections.Generic;
using NetTopologySuite.Geometries;

namespace Sk8M8_API.Models
{
    public class MapMarker : BaseEntity
    {
        public string Name { get; set; }
        public string LocationCategory { get; set; }
        public Point Point { get; set; }
        public Media Video { get; set; }
        public Client Creator { get; set; }
        public ICollection<ClientMarkerStar> ClientMarkerStars { get; set; }
    }
}
