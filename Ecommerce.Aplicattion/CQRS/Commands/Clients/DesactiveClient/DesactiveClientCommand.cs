using MediatR;
using System;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.DesactiveClient
{
    public class DesactiveClientCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
