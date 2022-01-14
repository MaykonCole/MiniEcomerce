using Ecommerce.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.GetUserByName
{
    public class GetUserByNameQuery : IRequest<List<User>>
    {
        public  string Name { get; set; }

        public GetUserByNameQuery(string name)
        {
            Name = name;
        }
    }
}
