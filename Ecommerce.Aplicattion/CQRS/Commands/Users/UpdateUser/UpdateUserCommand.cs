using MediatR;
using System;

namespace Ecommerce.Applicattion.CQRS.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool NotifyDescont { get; set; }
    }
}
