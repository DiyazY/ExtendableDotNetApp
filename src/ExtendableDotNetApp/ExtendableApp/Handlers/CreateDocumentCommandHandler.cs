using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtendableApp.Handlers
{
    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand>
    {
        private readonly IMediator _mediator;

        public CreateDocumentCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<Unit> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            // do some work
            Console.WriteLine("Document created!!!");
            
            //publishes notification that document was created
            _mediator.Publish(new DocumentCreated
            {
                Name = request.Name,
                Author = request.Author,
                CreatedAt = DateTime.Now
            }, cancellationToken);
            
            return Unit.Task;
        }
    }
}