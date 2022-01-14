using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Enums
{
    public enum TypeUserEnum
    {
        [Display(Name = "User")]
        User = 1,
        [Display(Name = "Admin")]
        Admin = 2,
    }
}
