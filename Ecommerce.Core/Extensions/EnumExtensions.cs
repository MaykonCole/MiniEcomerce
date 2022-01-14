using Ecommerce.Core.Enums;

namespace Ecommerce.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetValue(this TypeUserEnum type)
        {
            switch (type)
            {
                case TypeUserEnum.User:
                    return "User";
                default:
                    return "Admin";
            }
        }
    }
}
