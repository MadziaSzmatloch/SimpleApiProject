using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain;
using MyNewApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApi.Infrastructure
{
    internal class ProductRepository : IProductRepository
    {
        public MyApiDbContext myApiDbContext;
        public DbSet<Product> products;

        public ProductRepository(MyApiDbContext _myApiDbContext)
        {
            myApiDbContext = _myApiDbContext;
            products = myApiDbContext.Products;
        }

        public async Task<List<Product>> GetAll()
        {
            return await products.ToListAsync();
        }

        public async Task Add(Product product)
        {
            await products.AddAsync(product);
            await myApiDbContext.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            var forUpdate = await products.FirstAsync(p => p.Id == product.Id);
            forUpdate.Name = product.Name;
            forUpdate.Price = product.Price;
            forUpdate.AvailableQueantity = product.AvailableQueantity;

            await myApiDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var productToDelete = await products.FirstAsync(p => p.Id == id);
            products.Remove(productToDelete);

            await myApiDbContext.SaveChangesAsync();
        }
    }
}
