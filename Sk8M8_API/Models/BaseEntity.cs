using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Sk8M8_API.Models
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
