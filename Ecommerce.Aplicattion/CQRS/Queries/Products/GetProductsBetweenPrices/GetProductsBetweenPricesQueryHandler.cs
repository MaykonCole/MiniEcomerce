using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Queries.Products.GetProductsBetweenPrices
{
    public class GetProductsBetweenPricesQueryHandler : IRequestHandler<GetProductsBetweenPricesQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsBetweenPricesQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductViewModel>> Handle(GetProductsBetweenPricesQuery request, CancellationToken cancellationToken)
        {
            // VALIDACOES que poderiam já ser feitas via FLUENT VALIDATION - Evolucao
            if (request.MinimumPrice < 0 || request.MaximumPrice < 0)
                throw new Exception("Pricecs entered cannot be less than 0.");

            if (request.MinimumPrice > request.MaximumPrice)
                throw new Exception("Minimum Price cannot be higher than Maximum Price.");

            var productsBetweenPrices = await _productRepository.GetProductsBetweenPricesAsync(request.MinimumPrice, request.MaximumPrice);

            if (!productsBetweenPrices.Any())
                throw new Exception("There are no products between these prices: " + request.MinimumPrice + " and " + request.MaximumPrice);

            return request.ToProductViewModel(productsBetweenPrices);
        }
    }
}
