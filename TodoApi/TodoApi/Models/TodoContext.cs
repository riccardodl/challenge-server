using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TodoItem>().HasOne(t => t.Image).WithOne(f => f.Todo).HasForeignKey<FileUploaderItem>(i => i.TodoForeignKey);
            //modelBuilder.Entity<TodoItem>().HasOne(t => t.Image).WithOne(f => f.Todo).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TodoItem>().Property(t => t.Name).IsRequired();
        }

    }
}
