using System;
using System.Collections.Generic;

namespace Ecommerce.Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }
        public DateTime CreateAt { get; set; }
        public decimal Amount { get; set; }
        public bool Approved { get; set; }
    }
}
