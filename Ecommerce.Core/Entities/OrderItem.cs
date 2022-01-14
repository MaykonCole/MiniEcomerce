using System;


namespace Ecommerce.Core.Entities
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Client Client { get; set; }
    }
}
