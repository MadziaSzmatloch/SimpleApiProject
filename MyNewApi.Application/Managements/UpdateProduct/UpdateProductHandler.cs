﻿using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Exceptions;
using MyNewApi.Application.Managements.Mappings;
using MyNewApi.Application.Validators;
using MyNewApi.Domain.Entities;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.UpdateProduct
{
    public class UpdateProductHandler(IProductRepository productRepository, ProductValidator productValidator, IProductHistoryRepository productHistoryRepository) : IRequestHandler<UpdateProductRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ProductValidator _productValidator = productValidator;
        private readonly IProductHistoryRepository _productHistoryRepository = productHistoryRepository;

        public async Task<ProductDetailDto> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var productToEdit = await _productRepository.GetById(request.Id);
            if (productToEdit == null)
            {
                throw new NotFoundException($"Product with id: {request.Id} doesn't exist");
            }

            var product = new Product()
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                AvailableQuantity = request.AvailableQuantity,
                CategoryId = request.CategoryId,
            };

            _productValidator.Validate(product);
            await _productRepository.Update(product);

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
