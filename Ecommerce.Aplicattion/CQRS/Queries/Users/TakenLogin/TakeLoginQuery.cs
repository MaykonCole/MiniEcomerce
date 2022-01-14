using Ecommerce.Core.Entities;
using MediatR;

namespace Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin
{
    public class TakeLoginQuery : IRequest<User>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
