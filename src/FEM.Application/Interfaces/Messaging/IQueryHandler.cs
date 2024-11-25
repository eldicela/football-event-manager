

using MediatR;

namespace FEM.Application.Interfaces.Messaging;

internal interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
{
}
