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
            // do some work
            Console.WriteLine(
                $"The document '{notification.Name}' was created by {notification.Author} at {notification.CreatedAt}");

            return Task.CompletedTask;
        }
    }
}