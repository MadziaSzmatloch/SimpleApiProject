using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;

namespace MyNewApi.Infrastructure
{
    internal class MyApiDbContext : DbContext
    {
        public MyApiDbContext()
        {

        }

        public MyApiDbContext(DbContextOptions options)
            : base(options)
        { }


        public DbSet<Product> Products { get; set; }
    }
}
