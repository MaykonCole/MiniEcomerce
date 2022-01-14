using Ecommerce.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Tests.Users
{
    public class UserMock
    {
        public static User User { get; set; }
        public static User UserTwo { get; set; }
        public static User UserThree { get; set; }
        public static User UserFour { get; set; }
        public static List<User> ListUsers { get; set; } = new List<User>();

        public UserMock()
        {
            User = new User(Faker.Name.First(), Faker.Internet.Email(), Faker.RandomNumber.Next().ToString());
            UserTwo = new User(Faker.Name.First(), Faker.Internet.Email(), Faker.RandomNumber.Next().ToString());
            UserThree = new User(Faker.Name.First(), Faker.Internet.Email(), Faker.RandomNumber.Next().ToString());
            UserFour = new User(Faker.Name.First(), Faker.Internet.Email(), Faker.RandomNumber.Next().ToString());

            if (!ListUsers.Any())
            {
                ListUsers.Add(UserTwo);
                ListUsers.Add(UserThree);
                ListUsers.Add(UserFour);
            }
        }
    }
}
