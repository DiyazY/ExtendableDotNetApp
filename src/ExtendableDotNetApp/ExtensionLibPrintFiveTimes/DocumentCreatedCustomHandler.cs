using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtensionLibPrintFiveTimes
{
    public class DocumentCreatedCustomHandler: INotificationHandler<DocumentCreated>
    {
        public Task Handle(DocumentCreated notification, CancellationToken cancellationToken)
        {
            // do some work
            Console.WriteLine("Custom Handler");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(
                    $"The document '{notification.Name}' was created by {notification.Author} at {notification.CreatedAt}".PadLeft(5));    
            }
            

            return Task.CompletedTask;
        }
    }
}