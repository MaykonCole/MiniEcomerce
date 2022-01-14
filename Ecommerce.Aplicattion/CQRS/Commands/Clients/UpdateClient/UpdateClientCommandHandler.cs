using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;

        public UpdateClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<Guid> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var clientUpdated = await _clientRepository.UpdateClient(request.Id, request.Document);
            return clientUpdated;
        }
    }
}
