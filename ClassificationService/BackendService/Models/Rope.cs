using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models
{
    public enum Tag
    {
        [Display(Name = "Unspecified")]
        unspecified,
        [Display(Name = "Good rope")]
        goodRope,
        [Display(Name = "Bad rope")]
        badRope,
        [Display(Name = "No rope")]
        noRope
    }

    public class Rope
    {
        [Display(Name = "ID")]
        public int RopeID { get; set; }

        [DisplayFormat(NullDisplayText = "No tag")]
        public Tag Tag { get; set; }

        [Range(-1, 100.0)]
        public double Probability { get; set; }

        [Display(Name = "Date added")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedOn { get; set; }

        public ICollection<Image> Images { get; set; }

        public int ShipID { get; set; }
        public Ship Ship { get; set; }

    }
}
