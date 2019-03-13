using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BackendService.Models
{
    public class BackendServiceContext : DbContext
    {
        public BackendServiceContext (DbContextOptions<BackendServiceContext> options)
            : base(options)
        {
        }

        public DbSet<Ship> Ship { get; set; }
        public DbSet<Rope> Rope { get; set; }
        public DbSet<Image> Image { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>().Property(s => s.Name).IsRequired();
        }

    }
}
