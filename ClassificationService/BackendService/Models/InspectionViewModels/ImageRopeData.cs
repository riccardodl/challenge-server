using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models.InspectionViewModels
{
    public class ImageRopeData
    {

        public ICollection<Ship> Ships { get; set; }
        public IEnumerable<Rope> Ropes { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
