using System;

namespace Api.MiniEcommerce.Auth
{
    public class Token
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public DateTime DateExpiration { get; set; }
    }
}
