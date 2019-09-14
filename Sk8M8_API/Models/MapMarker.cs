using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class MapMarker : BaseEntity
    {
        public string Name { get; set; }
        public string LocationCategory { get; set; }
        public IPoint Point { get; set; }
        public Client Creator { get; set;  }
    }
}
