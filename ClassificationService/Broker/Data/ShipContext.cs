using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Broker.Models
{
    public class ShipContext : DbContext
    {
        public ShipContext (DbContextOptions<ShipContext> options)
            : base(options)
        {
        }

        public DbSet<Broker.Models.Ship> Ships { get; set; }
        public DbSet<Broker.Models.Rope> Ropes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ship>().ToTable("Ships");            
            modelBuilder.Entity<Ship>().Property(s => s.Name).IsRequired();

            modelBuilder.Entity<Rope>().ToTable("Ropes");
            modelBuilder.Entity<Rope>().Property(s => s.Tag).HasDefaultValue("unspecified");
            //modelBuilder.Entity<Rope>().Property(s => s.Ship).IsRequired();
            modelBuilder.Entity<Rope>()
               .HasKey(c => new { c.RopeID, c.Ship });

        }
    }
}
