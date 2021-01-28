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
        public ActionResult AddNewDocument([FromBody] CreateDocumentCommand command)
        {
            _mediator.Send(command);
            return Ok();
        }
    }
}