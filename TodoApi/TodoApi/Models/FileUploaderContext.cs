using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class FileUploaderContext : DbContext
    {
        public FileUploaderContext(DbContextOptions<FileUploaderContext> options) : base(options)
        {
        }

        public DbSet<FileUploaderItem> FileUploaderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<FileUploaderItem>().Property(t => t.Tag).IsRequired();
            modelBuilder.Entity<FileUploaderItem>().Property(t => t.Tag).HasDefaultValue("unspecified");
        }
    }
}
