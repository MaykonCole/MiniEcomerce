using Ecommerce.Core.Entities;
using Ecommerce.Core.IRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public GetUserByNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;   
        }
        public async Task<List<User>> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var usersByName = await _userRepository.GetUsersByNameAsync(request.Name);

            if (!usersByName.Any())
                throw new Exception("User with name : " + request.Name + " dont exists");

            return usersByName;
        }
    }
}
