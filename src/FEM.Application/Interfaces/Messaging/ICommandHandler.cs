

using MediatR;

namespace FEM.Application.Interfaces.Messaging;

public interface ICommandHandler<in TCommand, TRespond> : IRequestHandler<TCommand, TRespond> where TCommand : ICommand<TRespond>
{
}
