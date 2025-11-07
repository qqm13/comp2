using comp2.CommandList;
using comp2.DTO;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace comp2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("Auth")]
        public async Task<ActionResult<string>> Auth(LoginData loginData)
        {
            var command = new AuthCommand { LoginData = loginData };
            var result = await mediator.SendAsync(command);
            return Ok(result);
        }
    }
}
