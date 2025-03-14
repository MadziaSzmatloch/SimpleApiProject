﻿using Microsoft.EntityFrameworkCore;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Infrastructure.Repositories
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

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await products.FirstOrDefaultAsync(p => p.Id == id);
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
            forUpdate.AvailableQuantity = product.AvailableQuantity;

            await myApiDbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var productToDelete = await products.FirstAsync(p => p.Id == id);
            products.Remove(productToDelete);

            await myApiDbContext.SaveChangesAsync();
        }

        public Product ExistsByName(string name)
        {
            return myApiDbContext.Products.FirstOrDefault(p => p.Name == name);
        }
    }
}
