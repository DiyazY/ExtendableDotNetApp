using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtendableApp.Handlers
{
    public class CreateDocumentInAsyncWayCommandHandler: AsyncRequestHandler<CreateDocumentInAsyncWayCommand>
    {
        protected override Task Handle(CreateDocumentInAsyncWayCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Long Run Task ---------------------->");
            Console.WriteLine($"Long Run Task started at {DateTime.Now}");
            Thread.Sleep(5_000);
            Console.WriteLine($"Long Run Task finished at {DateTime.Now}");
            Console.WriteLine("Long Run Task <----------------------");
            return Task.CompletedTask;
        }
    }
}