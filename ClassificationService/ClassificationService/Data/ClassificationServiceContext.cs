using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ClassificationService.Models
{
    public class ClassificationServiceContext : DbContext
    {
        public ClassificationServiceContext (DbContextOptions<ClassificationServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ClassificationService.Models.Image> Image { get; set; }
    }
}
