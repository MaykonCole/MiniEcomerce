using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Clients.CreateClient
{
    class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;

        public CreateClientCommandHandler(IClientRepository clientRepository, IUserRepository userRepository)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var userById = await _userRepository.GetUserById(request.IdUser);
            if (userById == null)
                throw new Exception("User with Id " + request.IdUser + " dont exists!");
            var id = await _clientRepository.CreateClient(request.ToEntity(userById));
            return id;
        }
    }
}
