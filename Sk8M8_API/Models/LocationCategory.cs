using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class LocationCategory : BaseEntity
    {
        public Location Location { get; set; }
        public Category Category { get; set; }
    }
}
