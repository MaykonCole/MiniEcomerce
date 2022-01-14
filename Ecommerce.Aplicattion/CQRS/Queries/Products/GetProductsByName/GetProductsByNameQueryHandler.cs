using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Queries.Products.GetProductByName
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsByNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {
            var productsFilteredByName = await _productRepository.GetAllProductsByNameAsync(request.Name, request.UseLike);

            if (!productsFilteredByName.Any())
                throw new Exception("We have no Products in our stock with by name : " + request.Name);

            return request.ToProductViewModel(productsFilteredByName);
        }
    }
}
