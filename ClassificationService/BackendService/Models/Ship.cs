using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models
{
    public class Ship
    {
        public int ShipID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        public ICollection<Rope> Ropes { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
