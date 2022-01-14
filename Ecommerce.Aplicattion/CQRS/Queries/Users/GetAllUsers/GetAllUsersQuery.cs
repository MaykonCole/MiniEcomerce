using Ecommerce.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
