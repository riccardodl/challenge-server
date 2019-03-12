using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Broker.Models
{
    public enum TagsEnum
    {
        [Display(Name = "good rope")]
        good_rope,
        [Display(Name = "bad rope")]
        bad_rope,
        [Display(Name = "unspecified")]
        unspecified

    }
    public class Rope
    {
        public int RopeID { get; set; }
        [NotMappedAttribute]
        public IFormFile Image { get; set; }
        
        [Required]
        //[EnumDataType(typeof(TagsEnum), ErrorMessage = "The value doesn't exist within enum")]
        public string Tag { get; set; }

        [Display(Name = "Capture Date")]
        [DataType(DataType.Date)]
        public DateTime CaptureDate { get; set; }
        
        public Ship Ship { get; set; }   

    }
}
