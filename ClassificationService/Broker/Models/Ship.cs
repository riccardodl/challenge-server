using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public class Ship
    {
        public int ShipID { get; set; }
        public ICollection<Rope> Ropes { get; set; }
    }
}
