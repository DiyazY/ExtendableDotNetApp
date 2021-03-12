using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedEventsAndCommands;

namespace ExtensionLibTwitter
{
    public class PostMessageCommandHandler: IRequestHandler<PostMessageCommand>
    {
        public Task<Unit> Handle(PostMessageCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Twitter: `{request.Text}`");
            return Unit.Task;
        }
    }
}