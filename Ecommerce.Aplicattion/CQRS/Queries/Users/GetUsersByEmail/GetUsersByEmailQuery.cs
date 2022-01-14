using Ecommerce.Core.Entities;
using MediatR;
using System.Collections.Generic;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.GetUsersByEmail
{
    public class GetUsersByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }


        public GetUsersByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
