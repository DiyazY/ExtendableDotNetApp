using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedEventsAndCommands;

namespace ExtendableApp.Handlers.DummyEntity
{
    public class BusinessRulesBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : DummyEntityCommand // here you can restrict your behavior
        where TResponse : Models.DummyEntity // here you can restrict your behavior
    {
        private DummyEntityQueryRepo _repo = new DummyEntityQueryRepo(); // U know what to do with that ;)

        public BusinessRulesBehavior()
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            // request may contain the list of generated events which are valuable for business rules

            var preActionBusinessRules = _repo.GetDummyEntityPreActionBusinessRules(request.Id);
            
            // do business rules before
            // (probably, most of them would be validation rules, hence, it is better to perform them in the same context)
            foreach (var rule in preActionBusinessRules)
            {
                rule.Execute();
            }
            // if you want to stop the execution of a main handler, it would be useful to use DomainException

            var response = await next(); // here main handler will be executed. Like: save item

            response.Time = "hehe"; // there is a possibility of changing response!

            var postActionBusinessRules = _repo.GetDummyEntityPostActionBusinessRules(request.Id);
            // do business rules after
            // (probably, most of them would perform some post-action actions, hence, it is better to schedule them as background tasks (_mediator.Enqueue))
            foreach (var rule in postActionBusinessRules)
            {
                rule.Execute();
            }
            
            return response;
        }
    }
}