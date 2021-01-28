using MediatR;

namespace SharedEventsAndCommands
{
    public class CreateDocumentCommand: IRequest
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}