using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Core.Entities;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin
{
    public class TakeLoginHandler : IRequestHandler<TakeLoginQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public TakeLoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository
                ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<Ecommerce.Core.Entities.User> Handle(TakeLoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.TakeLoginAsync(request.Email, request.Password);

            if (user == null)
                throw new Exception("User not found. Email or Password incorect");
            return user;
        }
    }
}
