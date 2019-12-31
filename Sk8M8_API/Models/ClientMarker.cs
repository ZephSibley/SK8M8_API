using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class ClientMarker : BaseEntity
    {
        public Client User { get; set; }
        public MapMarker MapMarker { get; set; }
    }
}
