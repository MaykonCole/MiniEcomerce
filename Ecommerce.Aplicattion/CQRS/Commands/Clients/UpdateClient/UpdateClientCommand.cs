using MediatR;
using System;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.UpdateClient
{
    public class UpdateClientCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Document { get; set; }
    }
}
