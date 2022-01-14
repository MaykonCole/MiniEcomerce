using System;
using System.Collections.Generic;

namespace Ecommerce.Core.Entities
{
    public class Client : Base
    {
        public  string Document { get; set; }
        public int OrdersAmount { get; set; }
        public List<Phone> Phones { get; set; }
        public User User { get; set; }

        public Client()
        {

        }
        public Client(string document, User user)
        {
            Document = document;
            OrdersAmount = 0;
            Active = true;
            CreateAt = DateTime.Now;
            User = user;
        }
    }
}