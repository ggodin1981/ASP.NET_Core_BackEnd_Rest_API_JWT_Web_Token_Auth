using BookCatalog.Authorization.Model.Entities;
using BookCatalog.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog
{
    public class AuthorizeContexts : DbContext
    {
        public AuthorizeContexts(DbContextOptions<AuthorizeContexts> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Category { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
