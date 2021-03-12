using MediatR;

namespace SharedEventsAndCommands
{
    public class PostMessageCommand : IRequest
    {
        public string Text { get; set; }
    }
}