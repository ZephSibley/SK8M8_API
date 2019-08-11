using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class LocationCategory : BaseEntity
    {
        public MapMarker MapMarker { get; set; }
        public Category Category { get; set; }
    }
}
