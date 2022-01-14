using Ecommerce.Applicattion.CQRS.Commands.Clients.CreateClient;
using Ecommerce.Applicattion.CQRS.Commands.Clients.DesactiveClient;
using Ecommerce.Applicattion.CQRS.Commands.Clients.UpdateClient;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.MiniEcommerce.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(CreateClientCommand command)
        {
            try
            {
                var idClient = await _mediator.Send(command);
                return Ok(idClient);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient(UpdateClientCommand command)
        {
            try
            {
                var clientUpdated = await _mediator.Send(command);
                return Ok(clientUpdated);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DesactiveClient")]
        public async Task<IActionResult> DesactiveClient(DesactiveClientCommand command)
        {
            try
            {
                var desactiveClient = await _mediator.Send(command);
                if (desactiveClient)
                    return Ok("Client desactived");
                return Ok("Client is desactived");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
