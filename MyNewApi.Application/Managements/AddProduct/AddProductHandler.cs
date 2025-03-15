using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Exceptions;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Application.Validators;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.AddProduct
{
    public class AddProductHandler(IProductRepository productRepository, ProductValidator productValidator, IProductHistoryRepository productHistoryRepository, ICategoryRepository categoryRepository) : IRequestHandler<AddProductRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ProductValidator _productValidator = productValidator;
        private readonly IProductHistoryRepository _productHistoryRepository = productHistoryRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task<ProductDetailDto> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(request.CategoryId);
            if (category == null)
            {
                throw new NotFoundException($"Category with id: {request.CategoryId} doesn't exist");
            }

            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
                CategoryId = request.CategoryId,
            };

            _productValidator.Validate(product);
            await _productRepository.Add(product);

            await _productHistoryRepository.Add(new ProductHistory()
            {
                ProductId = product.Id,
                NewName = product.Name,
                NewPrice = product.Price,
                NewAvailableQuantity = product.AvailableQuantity,
                NewCategoryId = product.CategoryId,
                ModificationTime = DateTime.UtcNow
            });


            var mapper = new ProductMapper();
            return mapper.ProductToProductDetailDto(product);
        }
    }
}
