using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class FileUploaderItem
    {
        public long FileId { get; set; }
        public string ImageFilePath { get; set; }
        public string Tag { get; set; }

        [ForeignKey("Id")]
        public long TodoForeignKey { get; set; }
        public TodoItem Todo { get; set; }
    }
}
