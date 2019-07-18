using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
    }
}
