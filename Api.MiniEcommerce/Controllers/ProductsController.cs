using Ecommerce.Applicattion.CQRS.Queries.Products.GetAllProducts;
using Ecommerce.Applicattion.CQRS.Queries.Products.GetProductByName;
using Ecommerce.Applicattion.CQRS.Queries.Products.GetProductsBetweenPrices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.MiniEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ??
               throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetProductsByName")]
        public async Task<IActionResult> GetProductsByName(string name, bool useLike)
        {
            try
            {
                var products = await _mediator.Send(new GetProductsByNameQuery(name, useLike));
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetProductsBetweenPrices")]
        public async Task<IActionResult> GetProductsBetweenPrices(int minimumPrice, int maximumPrice)
        {
            try
            {
                var productsBetweenPrices = await _mediator.Send(new GetProductsBetweenPricesQuery(minimumPrice, maximumPrice));
                return Ok(productsBetweenPrices);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
