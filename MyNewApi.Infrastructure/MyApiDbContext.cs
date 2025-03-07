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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);


            base.OnModelCreating(builder);
        }
    }
}
