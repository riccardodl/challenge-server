using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public class Rope
    {
        public int RopeID { get; set; }
        [NotMappedAttribute]
        public IFormFile Image { get; set; }
        public string Tag { get; set; }

        [Display(Name = "Capture Date")]
        [DataType(DataType.Date)]
        public DateTime CaptureDate { get; set; }
        public Ship ShipID { get; set; }        
    }
}
