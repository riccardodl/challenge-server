using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public class Ship
    {
        public int ID { get; set; }
        public ICollection<Rope> Ropes { get; set; }
    }
}
