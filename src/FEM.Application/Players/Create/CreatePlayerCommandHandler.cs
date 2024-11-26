

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Players.Create;

internal class CreatePlayerCommandHandler : ICommandHandler<CreatePlayerCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreatePlayerCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }
    public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = new Player
        {
            Name = request.Name,
            Birthdate = request.Birthdate,
        };

        await _unitOfWork.PlayerRepository.AddAsync(player);
        await _unitOfWork.CommitAsync(cancellationToken);
        return player.Id;
    }
}
