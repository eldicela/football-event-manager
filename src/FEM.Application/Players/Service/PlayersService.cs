

using FEM.Application.DTOS;
using FEM.Application.Interfaces.Services;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Players.Service;

internal class PlayersService : IPlayersService
{
    private readonly IUnitOfWork _unitOfWork;
    public PlayersService(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();        
    }
    public async Task<IEnumerable<Player>> GetPlayersByIdsAsync(List<int> ids)
    {
        var players = await _unitOfWork.PlayerRepository.GetPlayersByTeamIdsAsync(ids);
        return players.Select(x => new Player
        {
              Id = x.Id,
               Birthdate = x.Birthdate,
                Name = x.Name,
        }).ToList();
    }
}
