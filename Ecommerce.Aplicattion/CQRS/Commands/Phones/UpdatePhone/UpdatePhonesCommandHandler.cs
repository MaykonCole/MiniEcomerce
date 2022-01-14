using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Phones.UpdatePhone
{
    public class UpdatePhonesCommandHandler : IRequestHandler<UpdatePhonesCommand, Guid>
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly IClientRepository _clientRepository;

        public UpdatePhonesCommandHandler(IPhoneRepository phoneRepository, IClientRepository clientRepository)
        {
            _phoneRepository = phoneRepository;
            _clientRepository = clientRepository;
        }
        public async Task<Guid> Handle(UpdatePhonesCommand request, CancellationToken cancellationToken)
        {
            var guidPhone = await _phoneRepository.UpdatePhone(request.ClientId, request.ToEntity());
            return guidPhone;
        }
    }
}
