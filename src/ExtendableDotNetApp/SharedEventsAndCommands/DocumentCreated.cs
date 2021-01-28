using System;
using MediatR;

namespace SharedEventsAndCommands
{
    public class DocumentCreated: INotification
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public  DateTime CreatedAt { get; set; }
    }
}