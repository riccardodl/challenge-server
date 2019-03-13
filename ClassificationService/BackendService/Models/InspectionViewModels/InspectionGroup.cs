using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models.InspectionViewModels
{
    public class InspectionGroup
    {
        public string ShipName { get; set; }
        public int RopesCount { get; set; }
        public List<Tuple<Tag,int>> Tags { get; set; }
    }
}
