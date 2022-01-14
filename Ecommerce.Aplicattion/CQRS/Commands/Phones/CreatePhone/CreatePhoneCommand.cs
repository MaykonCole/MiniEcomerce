using Ecommerce.Aplicattion.Dtos.InputModels;
using Ecommerce.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Commands.Phones.CreatePhone
{
    public class CreatePhoneCommand : IRequest<Unit>
    {
        public Guid ClientId { get; set; }
        public List<PhoneInputModel> MyPhones { get; set; }

        public List<Phone> ToEntity(Client client)
        {
            List<Phone> phones = new List<Phone>();

            foreach (var p in MyPhones)
            {
                var phone = new Phone(p.Number, p.MainContact, p.IsWhatSap, client);
                phones.Add(phone);
            }
            return phones;
        }
    }
}
