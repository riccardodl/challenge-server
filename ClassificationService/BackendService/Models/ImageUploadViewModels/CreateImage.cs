using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendService.Models.ImageUploadViewModels
{
    public class CreateImage
    {
        public IFormFile Image { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [Display(Name = "Capture Date")]
        [DataType(DataType.Date)]
        public DateTime CaptureDate { get; set; }
    }
}
