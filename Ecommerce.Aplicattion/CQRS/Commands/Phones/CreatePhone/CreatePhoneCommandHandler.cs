using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Phones.CreatePhone
{
    public class CreatePhoneCommandHandler : IRequestHandler<CreatePhoneCommand, Unit>
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IClientRepository _clientRepository;

        public CreatePhoneCommandHandler(IPhoneRepository phoneRepository, IClientRepository clientRepository)
        {
            _phoneRepository = phoneRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Unit> Handle(CreatePhoneCommand request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetClientById(request.ClientId);
            if (client == null)
                throw new Exception("Client not found : " + request.ClientId);
            await _phoneRepository.CreatePhone(request.ToEntity(client));
            return Unit.Value;
        }
    }
}
