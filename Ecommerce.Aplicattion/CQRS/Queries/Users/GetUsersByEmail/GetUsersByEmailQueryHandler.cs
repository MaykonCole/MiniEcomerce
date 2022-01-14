using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.GetUsersByEmail
{
    public class GetUsersByEmailQueryHandler : IRequestHandler<GetUsersByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;
        public GetUsersByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Handle(GetUsersByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
                throw new Exception("There are no Users with this Email : " + request.Email);

            return user;
        }
    }
}
