﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.DataClasses
{
    public class PointCreationRequest
    {
        public string name { get; set; }
        public string category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
