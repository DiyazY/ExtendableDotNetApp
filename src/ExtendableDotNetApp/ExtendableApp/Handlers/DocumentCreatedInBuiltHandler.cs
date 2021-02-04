using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtendableApp.Handlers
{
    public class DocumentCreatedInBuiltHandler : INotificationHandler<DocumentCreated>
    {
        public Task Handle(DocumentCreated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("In built handler ---------------------->");
            // do some work
            Console.WriteLine(
                $"The document '{notification.Name}' was created by {notification.Author} at {notification.CreatedAt}");
            Console.WriteLine("In built handler <----------------------");
            return Task.CompletedTask;
        }
    }
}