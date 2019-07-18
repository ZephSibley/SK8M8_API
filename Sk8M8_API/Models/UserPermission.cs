using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sk8M8_API.Models
{
    public class UserPermission : BaseEntity
    {
        public Client Client { get; set; }
        public Permission Permission { get; set; }
    }
}
