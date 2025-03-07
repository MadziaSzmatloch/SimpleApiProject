using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyNewApi.Application.Managements.AddProduct;
using MyNewApi.Application.Managements.DeleteProduct;
using MyNewApi.Application.Managements.GetAllProducts;
using MyNewApi.Application.Managements.GetProductById;
using MyNewApi.Application.Managements.UpdateProduct;
using MyNewApi.Domain;

namespace MyNewApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(IProductRepository productRepository, IMediator mediator) : ControllerBase
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductsRequest());
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdRequest() { Id = id });
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductRequest request)
        {
            var p = await _mediator.Send(request);
            return Ok(p);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductRequest request)
        {
            var p = await _mediator.Send(request);
            return Ok(p);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteProductRequest() { Id = id });
            return Ok();
        }
    }
}
