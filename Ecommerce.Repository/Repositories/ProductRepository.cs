using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.ApiRepository.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EcommerceDbContext _dbContext;

        public ProductRepository(EcommerceDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentException(nameof(dbContext));
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            var allProductsAtTheStock = await _dbContext.Products.Where(x => x.InStock > 0).ToListAsync();
            return allProductsAtTheStock;
        }

        public async Task<List<Product>> GetAllProductsByNameAsync(string name, bool useLike)
        {
            var productsFiltered = useLike ?
                await _dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync()
              : await _dbContext.Products.Where(x => x.Name.Equals(name)).ToListAsync();
            return productsFiltered;
        }

        public async Task<List<Product>> GetProductsBetweenPricesAsync(int minimumPrice, int maximumPrice)
        {
            var productsBetweenPrices = await _dbContext.Products.Where(p => p.Price >= minimumPrice && p.Price <= maximumPrice).ToListAsync();
            return productsBetweenPrices;
        }
    }
}
