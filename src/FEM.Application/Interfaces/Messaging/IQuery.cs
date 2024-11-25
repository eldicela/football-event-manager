

using MediatR;

namespace FEM.Application.Interfaces.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse> 
{
}
