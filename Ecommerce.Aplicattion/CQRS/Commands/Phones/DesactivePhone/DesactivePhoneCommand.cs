using MediatR;
using System;

namespace Ecommerce.Applicattion.CQRS.Commands.Phones.DesactivePhone
{
    public class DesactivePhoneCommand : IRequest<bool>
    {
        public Guid ClientId { get; set; }
        public string Number { get; set; }

        public DesactivePhoneCommand(Guid clientId, string number)
        {
            ClientId = clientId;
            Number = number;
        }
    }
}
