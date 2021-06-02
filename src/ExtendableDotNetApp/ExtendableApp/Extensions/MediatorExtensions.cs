using System;
using System.Linq.Expressions;
using ExtendableApp.Helpers;
using Hangfire;
using MediatR;

namespace ExtendableApp.Extensions
{
    public static class MediatorExtensions
    {
        public static void Enqueue(this IMediator mediator, string jobName, IRequest request)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(jobName, request));
        }

        public static void Enqueue(this IMediator mediator,IRequest request)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(request));
        }
        
        public static void Enqueue(this IMediator mediator, string jobName, INotification notification)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(jobName, notification));
        }

        public static void Enqueue(this IMediator mediator,INotification notification)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Publish(notification));
        }
    }
}