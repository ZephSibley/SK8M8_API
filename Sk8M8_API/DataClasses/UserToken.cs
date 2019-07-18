using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.DataClasses
{
    public class UserToken
    {
        public long ClientId { get; set; }
        public long Exp { get; set; }
    }
}
