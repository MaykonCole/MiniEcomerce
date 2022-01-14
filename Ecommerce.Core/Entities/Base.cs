using System;

namespace Ecommerce.Core.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public DateTime? DesactiveAt { get; set; }
        public bool Active { get; set; }
    }
}
