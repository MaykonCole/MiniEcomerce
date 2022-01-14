using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var productsInStock = await _productRepository.GetAllProductsAsync();

            if (!productsInStock.Any())
                throw new Exception("We have no Products in our stock.");
            
            return request.ToProductViewModel(productsInStock);
        }
    }
}
