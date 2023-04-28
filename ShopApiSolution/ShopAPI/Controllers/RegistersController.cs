using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Models.ViewModels.Register;
using ShopAPI.Services.Registers.Commands.CreateRegister;
using System.Threading.Tasks;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RegistersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> CreateRegisterAsync([FromRoute] string userId
                                                            , [FromBody] RegisterRequestViewModel request)
        {
            return Ok(await _mediator.Send(new CreateRegisterCommand(userId, request)));
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateRegisterAsync([FromRoute] string userId
                                                            , [FromBody] RegisterRequestViewModel request)
        {
            return Ok(await _mediator.Send(new UpdateRegisterCommand(userId, request)));
        }
    }
}
