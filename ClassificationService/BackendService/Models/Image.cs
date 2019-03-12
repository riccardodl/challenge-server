using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public byte[] RawImage { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [Display(Name = "Capture Date")]
        [DataType(DataType.Date)]
        public DateTime CaptureDate { get; set; }
        
        public int RopeID { get; set; }
        public Rope Rope { get; set; }
    }
}
