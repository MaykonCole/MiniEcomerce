using Ecommerce.Aplicattion.Dtos.InputModels;
using Ecommerce.Core.Entities;
using MediatR;
using System;


namespace Ecommerce.Applicattion.CQRS.Commands.Phones.UpdatePhone
{
    public class UpdatePhonesCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }
        public PhoneInputModel Phone { get; set; }

        public Phone ToEntity ()
        {
            Phone phoneUpdate = new Phone(Phone.Number, Phone.MainContact, Phone.IsWhatSap, null);
            return phoneUpdate;
        }
    }
}
