using Ecommerce.Core.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.DesactiveClient
{
    public class DesactiveClientCommandHandler : IRequestHandler<DesactiveClientCommand, bool>
    {
        private readonly IClientRepository _clientRepository;
        public DesactiveClientCommandHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public async Task<bool> Handle(DesactiveClientCommand request, CancellationToken cancellationToken)
        {
            var desactiveClient = await _clientRepository.DesactiveClient(request.Id);
            return desactiveClient;
        }
    }
}
