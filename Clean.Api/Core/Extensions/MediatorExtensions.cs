using System.Threading.Tasks;
using Clean.Api.Core.ActionResults;
using Clean.FeatureSets.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Core.Extensions
{
    public static class MediatorExtensions
    {
        public static Task<IActionResult> Send<TC, TIn, TOut>(this IMediator mediator, TIn value) 
            where TC : IRequest<TOut>, IModel<TIn>, new() 
            where TOut : class
        {
            var command = new TC {Model = value};
            return mediator.Send(command).Response();
        }
    }
}