using Api.MiniEcommerce.Auth;
using AutoMapper;
using Ecommerce.Aplicattion.Dtos.ViewModels;
using Ecommerce.Applicattion.CQRS.Commands.Clients.DesactiveClient;
using Ecommerce.Applicattion.CQRS.Commands.Users.CreateUser;
using Ecommerce.Applicattion.CQRS.Commands.Users.UpdateUser;
using Ecommerce.Applicattion.CQRS.Queries.Users.GetAllUsers;
using Ecommerce.Applicattion.CQRS.Queries.Users.GetUserByName;
using Ecommerce.Applicattion.CQRS.Queries.Users.GetUsersByEmail;
using Ecommerce.Applicattion.CQRS.Queries.Users.TakenLogin;
using Ecommerce.Core.Entities;
using Ecommerce.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.MiniEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ??
                throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _mediator.Send(new GetAllUsersQuery());
                var usersViewModel = new List<UserViewModel>();
                usersViewModel = users.Select(_mapper.Map<User, UserViewModel>).ToList();
                return Ok(usersViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUsersByEmail(string email)
        {
            try
            {
                var usersByEmail = await _mediator.Send(new GetUsersByEmailQuery(email));
                var userViewModel = _mapper.Map<UserViewModel>(usersByEmail);
                return Ok(userViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetUsersByName")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                var usersByName = await _mediator.Send(new GetUserByNameQuery(name));
                var usersViewModel = new List<UserViewModel>();
                usersViewModel = usersByName.Select(_mapper.Map<User, UserViewModel>).ToList();
                return Ok(usersViewModel);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> CreateToken([FromServices] JwtConfiguration jwtConfiguration,
           [FromBody] TakeLoginQuery command)
        {
            try
            {
                var userDataBase = await  _mediator.Send(command);
                var jwt = new Jwt(jwtConfiguration);
                return Ok(jwt.GerarToken(userDataBase.Email, userDataBase.TypeUser.GetValue(), userDataBase.Name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            try
            {
                var iduser = await _mediator.Send(command);
                return Ok(iduser);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            try
            {
                var userId = await _mediator.Send(command);
                return Ok(userId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DesactiveUser")]
        public async Task<IActionResult> DesactiveUser(DesactiveClientCommand command)
        {
            try
            {
                var desactivedUser = await _mediator.Send(command);
                if (desactivedUser)
                    return Ok("User desactived");
                return Ok("User is desactived");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
