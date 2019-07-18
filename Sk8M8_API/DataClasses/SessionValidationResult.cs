using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sk8M8_API.Enums;

namespace Sk8M8_API.DataClasses
{
    public class SessionValidationResult
    {
        public SessionValidationResultStatus Status { get; set; }
        public object Session { get; set; }
    }
}
