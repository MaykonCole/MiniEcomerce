using Ecommerce.Applicattion.CQRS.Commands.Phones.CreatePhone;
using Ecommerce.Applicattion.CQRS.Commands.Phones.DesactivePhone;
using Ecommerce.Applicattion.CQRS.Commands.Phones.UpdatePhone;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Api.MiniEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhonesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreatePhone")]
        public async Task<IActionResult> CreatePhones(CreatePhoneCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("Created Phones");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdatePhone")]
        public async Task<IActionResult> UpdatePhone(UpdatePhonesCommand command)
        {
            try
            {
                var guidPhone = await _mediator.Send(command);
                return Ok("Updated Phone " + guidPhone);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("DesactivePhone")]
        public async Task<IActionResult> DesactivePhone(DesactivePhoneCommand command)
        {
            try
            {
                var desactivePhone = await _mediator.Send(command);
                if (desactivePhone)
                    return Ok("Phone desactived");
                return Ok("Phone is desactived");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
