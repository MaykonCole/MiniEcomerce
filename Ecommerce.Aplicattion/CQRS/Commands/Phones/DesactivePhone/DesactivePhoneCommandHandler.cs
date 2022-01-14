using Ecommerce.Core.IRepositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Phones.DesactivePhone
{
    public class DesactivePhoneCommandHandler : IRequestHandler<DesactivePhoneCommand, bool>
    {
        private readonly IPhoneRepository _phoneRepository;

        public DesactivePhoneCommandHandler(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        public async Task<bool> Handle(DesactivePhoneCommand request, CancellationToken cancellationToken)
        {
            var desactivePhone = await _phoneRepository.DesactivePhone(request.ClientId, request.Number);
            return desactivePhone;
        }
    }
}
