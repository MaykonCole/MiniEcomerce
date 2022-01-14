using Ecommerce.Core.Enums;
using System;

namespace Ecommerce.Core.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public int CountLogin { get; set; }
        public bool NotifyDescont { get; set; }
        public TypeUserEnum TypeUser { get; set; }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;

            CountLogin = 1;
            NotifyDescont = true;
            TypeUser = TypeUserEnum.User;
            CreateAt = DateTime.Now;
            Active = true;
        }

        public static User ToEntity(string name, string email, string password)
        {
            var user = new User(name, email, password);
            return user;
        }
    }
}
