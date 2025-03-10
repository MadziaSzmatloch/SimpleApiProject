﻿using MyNewApi.Domain.Entities;

namespace MyNewApi.Domain
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product> GetById(int id);
        public Task Add(Product product);
        public Task Update(Product product);
        public Task Delete(int id);
    }
}
