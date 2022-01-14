using Ecommerce.Core.Entities;
using MediatR;
using System;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public string Document { get; set; }
        public Guid IdUser { get; set; }
    
        public Client ToEntity(User user)
        {
            return new Client(Document, user);
        }
    }
}
