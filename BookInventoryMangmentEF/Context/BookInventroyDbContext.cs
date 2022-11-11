using BookInventoryMangmentEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookInventoryMangmentEF.Context
{
    public class BookInventroyDbContext : DbContext
    {
        public BookInventroyDbContext()
        {

        }
        public BookInventroyDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<BookInventory> BookInventory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookInventory>(
                entity =>
                {
                    entity.HasKey(e => e.BookId);
                    entity.Property(e => e.Price);
                    entity.Property(e => e.Quantity);
                    entity.Property(e => e.Author);
                    entity.Property(e=>e.BookName);
                }
                );
            
        }
       
    }
}
