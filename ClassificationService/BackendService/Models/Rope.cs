using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models
{
    public enum Tag
    {
        unspecified,
        goodRope,
        badRope,
        noRope
    }

    public class Rope
    {
        [Display(Name = "ID")]
        public int RopeID { get; set; }
        [DisplayFormat(NullDisplayText = "No tag")]
        public Tag Tag { get; set; }
        public double Probability { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime AddedOn { get; set; }

        public ICollection<Image> Images { get; set; }

        public int ShipID { get; set; }
        public Ship Ship { get; set; }
    }
}
