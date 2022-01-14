using Ecommerce.Core.Enums;

namespace Ecommerce.Aplicattion.Dtos.ViewModels
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public decimal Price { get; set; }
        public string Details { get; set; }
    }
}
