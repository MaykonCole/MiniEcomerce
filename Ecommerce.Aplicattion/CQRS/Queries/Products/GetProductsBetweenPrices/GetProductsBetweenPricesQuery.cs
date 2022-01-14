using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Queries.Products.GetProductsBetweenPrices
{
    public class GetProductsBetweenPricesQuery : IRequest<List<ProductViewModel>>
    {
        public int MinimumPrice { get; set; }
        public int MaximumPrice { get; set; }

        public GetProductsBetweenPricesQuery(int minimumPrice, int maximumPrice)
        {
            MinimumPrice = minimumPrice;
            MaximumPrice = maximumPrice;
        }

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
