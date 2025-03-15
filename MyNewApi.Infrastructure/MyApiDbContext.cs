using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;

namespace MyNewApi.Infrastructure
{
    public class MyApiDbContext : DbContext
    {
        public MyApiDbContext()
        {

        }

        public MyApiDbContext(DbContextOptions options)
            : base(options)
        { }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BannedWord> BannedWords { get; set; }
        public DbSet<ProductHistory> ProductHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BannedWord>()
                .HasIndex(x => x.Word)
                .IsUnique();
        }
    }
}
