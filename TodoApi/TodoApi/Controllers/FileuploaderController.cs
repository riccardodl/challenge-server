using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    public class FileuploaderController : Controller
    {
        private readonly FileUploaderContext _context;

        public FileuploaderController(FileUploaderContext context)
        {
            _context = context;            
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> PostImage(List<IFormFile> files, TodoItem item)
        {
            long size = files.Sum(f => f.Length);
            var image = new FileUploaderItem
            { TodoForeignKey = item.Id, Todo = item };
            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {                
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                        image.ImageFilePath = filePath;
                        _context.Add(image);
                        await _context.SaveChangesAsync();
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}