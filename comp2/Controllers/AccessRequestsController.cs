using comp2.CommandList;
using comp2.DTO;
using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;

namespace comp2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessRequestsController : ControllerBase
    {
        IMediator mediator;
        public AccessRequestsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("AccesRequest")]
        public async void AccesRequest()
        {
            
        }
    }
}
