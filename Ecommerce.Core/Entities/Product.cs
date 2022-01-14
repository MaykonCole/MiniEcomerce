using Ecommerce.Core.Enums;
using System;

namespace Ecommerce.Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
        public int InStock { get; set; }
    }
}
