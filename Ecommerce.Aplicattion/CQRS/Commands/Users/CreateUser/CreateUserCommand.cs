using Ecommerce.Aplicattion.Dtos.InputModels;
using Ecommerce.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Applicattion.CQRS.Commands.Users.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public UserInputModel UserInputModel { get; set; }

        public User ToEntity()
        {
            return new User(UserInputModel.Name, UserInputModel.Email, UserInputModel.Password);
        }
    }
}
