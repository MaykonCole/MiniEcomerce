using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Users.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            if (!string.IsNullOrEmpty(request.UserInputModel.Name) &&
                !string.IsNullOrEmpty(request.UserInputModel.Email) &&
                !string.IsNullOrEmpty(request.UserInputModel.Password))
            {
                var idUser = await _userRepository.AddUserAsync(request.ToEntity());
                return idUser;
            }
            else
            {
                throw new Exception("Name or Email or Password empty");
            }
        }
    }
}
