using MediatR;
using MyNewApi.Application.DTO;
using MyNewApi.Application.Mappings;
using MyNewApi.Domain.Interfaces;

namespace MyNewApi.Application.Managements.GetAllProductHistory
{
    public class GetAllProductHistoryHandler(IProductHistoryRepository productHistoryRepository) : IRequestHandler<GetAllProductHistoryRequest, IEnumerable<ProductHistoryDto>>
    {
        private readonly IProductHistoryRepository _productHistoryRepository = productHistoryRepository;

        public async Task<IEnumerable<ProductHistoryDto>> Handle(GetAllProductHistoryRequest request, CancellationToken cancellationToken)
        {
            var mapper = new ProductHistoryMapper();
            var histories = await _productHistoryRepository.Get();
            return histories.Select(mapper.ProductHistoryToProductHistoryDto);
        }
    }
}
