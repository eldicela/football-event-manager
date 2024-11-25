
using MediatR;

namespace FEM.Application.Interfaces.Messaging;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
