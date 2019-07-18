using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sk8M8_API.Models;

namespace Sk8M8_API.Controllers
{
    public class DiscoveryController : Controller
    {
        private SkateContext Context { get; set; }

        public DiscoveryController(SkateContext context)
        {
            this.Context = context;
        }

        public ActionResult Find(decimal Latitude, decimal Longtitude)
        {
            Context.Location.Where(x => () {
                var i = 0;
                return i > 1;
            });
            context
        }
    }
}
