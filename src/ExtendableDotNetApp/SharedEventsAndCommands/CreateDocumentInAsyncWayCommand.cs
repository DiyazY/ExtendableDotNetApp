using MediatR;

namespace SharedEventsAndCommands
{
    public class CreateDocumentInAsyncWayCommand: IRequest
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }
}