using System;
using System.Threading.Tasks;
using ExtendableApp.Extensions;
using ExtendableApp.Handlers.DummyEntity;
using ExtendableApp.Models;
using Hangfire;
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
        
        //POST
        [HttpPost("async")]
        public ActionResult AddNewDocumentAsync([FromBody] CreateDocumentInAsyncWayCommand command)
        {
            // go to https://localhost:53285/hangfire
             _mediator.Enqueue("Run Background Job", command);
            return Ok();
        }
        

        [HttpPost("post-message")]
        public async Task<ActionResult> PostMessage([FromBody] PostMessageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        
        [HttpPost("dummy")]
        public async Task<ActionResult<DummyEntity>> Dummy([FromBody] DummyEntityCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}