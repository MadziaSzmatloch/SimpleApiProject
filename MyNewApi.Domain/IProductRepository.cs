using MyNewApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNewApi.Domain
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll();
        public Task Add(Product product);
        public Task Update(Product product);
        public Task Delete(int id); 
    }
}
