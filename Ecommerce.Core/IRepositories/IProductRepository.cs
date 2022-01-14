using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Core.IRepositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsByNameAsync(string name, bool useLike);
        Task<List<Product>> GetProductsBetweenPricesAsync(int minimumPrice, int maximumPrice);
    }
}
