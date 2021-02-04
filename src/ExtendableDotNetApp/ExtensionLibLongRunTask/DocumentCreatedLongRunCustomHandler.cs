using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtensionLibLongRunTask
{
    public class DocumentCreatedLongRunCustomHandler : INotificationHandler<DocumentCreated>
    {
        public Task Handle(DocumentCreated notification, CancellationToken cancellationToken)
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