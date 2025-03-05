using Microsoft.AspNetCore.Mvc;
using MyNewApi.Domain;
using MyNewApi.Domain.Entities;
using MyNewApi.Infrastructure;
using System.Collections;

namespace MyNewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await repository.GetAll();
            //var products = new List<Product> { new Product() { Id = 1, Name="Pen", Price=10, AvailableQueantity=10 } };
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await repository.Add(product);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product product)
        {
            await repository.Update(product);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await repository.Delete(id);
            return Ok();
        }
    }
}
