using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedEventsAndCommands;

namespace ExtendableApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DocumentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //POST
        [HttpPost]
        public async Task<ActionResult> AddNewDocument([FromBody] CreateDocumentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("post-message")]
        public async Task<ActionResult> PostMessage([FromBody] PostMessageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}