using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Core.Enums
{
    public enum CategoryEnum
    {
        [Display(Name = "Eletronicos")]
        Electronics = 1,
        [Display(Name = "Moveis")]
        Furniture = 2,
        [Display(Name = "Vestuario")]
        Clothing = 3,
        [Display(Name = "Jogos")]
        Games = 4,
        [Display(Name = "Outros")]
        Others = 5,
    }
}
