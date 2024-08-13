using BookCatalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
           //Database.Migrate();
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = Guid.NewGuid(),               
                Name = "Drama"
            }, new Category
            {
                Id = Guid.NewGuid(),               
                Name = "Fantasy"
            });
        }
    }
}
