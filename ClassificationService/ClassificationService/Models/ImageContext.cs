using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassificationService.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options)
           : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
    }
}
