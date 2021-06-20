using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class DummyEntityCommandHandler: IRequestHandler<DummyEntityCommand,Models.DummyEntity>
    {
        public Task<Models.DummyEntity> Handle(DummyEntityCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("main action execution!");
            return Task.FromResult(new Models.DummyEntity()
            {
                Id = request.Id,
                Time = DateTime.Now.ToString()
            });
        }
    }
}