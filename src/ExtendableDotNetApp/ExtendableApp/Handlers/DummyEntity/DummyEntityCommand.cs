using MediatR;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class DummyEntityCommand: IRequest<Models.DummyEntity>
    {
        public int Id { get; set; }
    }
}