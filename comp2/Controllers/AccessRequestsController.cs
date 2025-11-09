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
        public async Task<ActionResult> AccesRequest(int resourceId)
        {
            var command = new RequestAddCommand { User = User.Claims.First(), ResourceId = resourceId };
            await mediator.SendAsync(command);
            return Ok();
        }

        [HttpPost("AllAccesRequests")]
        public async Task<IEnumerable<AccessRequestDTO>> AllAccesRequests()
        {
            var command = new AllRequestsCommand { User = User.Claims.First() };
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpPost("AllAccesUnseenRequests")]
        public async Task<IEnumerable<AccessRequestDTO>> AllAccesUnseenRequests()
        {
            var command = new AllUnSeenRequestsCommand { User = User.Claims.First() };
            var result = await mediator.SendAsync(command);
            return result;
        }

        [HttpPost("RequestYes")]
        public async Task<ActionResult> RequestYes(int requestId)
        {
            var command = new YesAccesRequestCommand { User = User.Claims.First(), RequestId = requestId };
            await mediator.SendAsync(command);
            return Ok();
        }

        [HttpPost("RequestNo")]
        public async Task<ActionResult> RequestNo(int requestId, string rejectionReason)
        {
            var command = new NoAccesRequestCommand { User = User.Claims.First(), RequestId = requestId,  RejectionReason = rejectionReason};
            await mediator.SendAsync(command);
            return Ok();
        }
    }
}
