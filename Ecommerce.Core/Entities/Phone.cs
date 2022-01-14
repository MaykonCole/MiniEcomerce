using System;

namespace Ecommerce.Core.Entities
{
    public class Phone: Base
    {
        public string Number { get; set; }
        public bool MainContact { get; set; }
        public bool IsWhatSap { get; set; }
        public Client Client { get; set; }
        
        public Phone()
        {

        }
        public Phone(string number, bool mainContact, bool isWhatSap, Client client)
        {
            Number = number;
            MainContact = mainContact;
            IsWhatSap = isWhatSap;
            Client = client;

            CreateAt = DateTime.Now;
            Active = true;
        }
    }
}