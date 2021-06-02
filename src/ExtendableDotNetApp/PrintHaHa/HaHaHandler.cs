using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace PrintHaHa
{
    public class HaHaHandler: INotificationHandler<DocumentCreated>
    {
        public Task Handle(DocumentCreated notification, CancellationToken cancellationToken)
        {

            Console.WriteLine("Ha ha ha ha!!!!");

            return Task.CompletedTask;
        }
    }
}