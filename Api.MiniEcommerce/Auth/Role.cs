using Ecommerce.Core.Enums;
using Ecommerce.Core.Extensions;

namespace Api.MiniEcommerce.Auth
{
    public static class Role
    {
        public static string Read = TypeUserEnum.User.GetValue();
        public static string Write = TypeUserEnum.Admin.GetValue();
    }
}
