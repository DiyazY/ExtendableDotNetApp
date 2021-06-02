using System.ComponentModel;
using System.Threading.Tasks;
using MediatR;

namespace ExtendableApp.Helpers
{
    public class MediatorHangfireBridge
    {
        private readonly IMediator _mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(IRequest command)
        {
            await _mediator.Send(command);
        }

        [DisplayName("{0}")]
        public async Task Send(string jobName, IRequest command)
        {
            await _mediator.Send(command);
        }
        
        public async Task Publish(INotification notification)
        {
            await _mediator.Publish(notification);
        }

        [DisplayName("{0}")]
        public async Task Publish(string jobName, INotification notification)
        {
            await _mediator.Publish(notification);
        }
    }
}