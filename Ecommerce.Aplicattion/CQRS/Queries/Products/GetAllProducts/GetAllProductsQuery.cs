using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Queries.Products.GetAllProducts
{
    public  class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public List<ProductViewModel> ToProductViewModel(List<Product> products)
        {
            var productsViewModelList = new List<ProductViewModel>();

            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel();
                productViewModel.Name = product.Name;
                productViewModel.Category = product.Category;
                productViewModel.Price = product.Price;
                productViewModel.Details = product.Details;

                productsViewModelList.Add(productViewModel);
            }

            return productsViewModelList;
        }
    }
}
