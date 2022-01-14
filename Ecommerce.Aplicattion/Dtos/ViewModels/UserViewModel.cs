using Ecommerce.Core.Enums;

namespace Ecommerce.Aplicattion.Dtos.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public TypeUserEnum TypeClient { get; set; }
    }
}
