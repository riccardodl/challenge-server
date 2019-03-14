using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models.InspectionViewModels
{
    public class RopeShipName
    {
        public string ShipName { get; set; }
        public int RopeID { get; set; }
        public int ShipID { get; set; }
        public bool Selected { get; set; }
    }
}
