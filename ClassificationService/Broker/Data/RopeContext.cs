using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Broker.Models
{
    public class RopeContext : DbContext
    {
        public RopeContext (DbContextOptions<RopeContext> options)
            : base(options)
        {
        }

        public DbSet<Broker.Models.Rope> Rope { get; set; }
    }
}
