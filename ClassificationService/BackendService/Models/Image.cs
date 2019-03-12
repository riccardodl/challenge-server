using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

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

        //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.imaging?redirectedfrom=MSDN&view=netframework-4.7.2#remarks
        public static Bitmap FromByteArray(byte[] rawImg)
        {
            using (MemoryStream memoryStream = new MemoryStream(rawImg))
            {
                Bitmap image = (Bitmap)System.Drawing.Image.FromStream(memoryStream);                
                return image;
            }
        }
    }
}
