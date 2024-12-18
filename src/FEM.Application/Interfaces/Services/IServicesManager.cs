﻿

namespace FEM.Application.Interfaces.Services;

public interface IServicesManager
{
    #region Services
    public IFootballClubPlayerService FootballClubPlayersService { get; }
    public IMatchStatisticsService MatchStatisticsService { get; }
    public IPlayersService PlayersService { get; }
    public IMatchesService MatchesService { get; }
    public IFootballClubsService FootballClubsService { get; }
    #endregion
    T WrapInTransaction<T>(Func<T> action);
    Task<T> WrapInTransactionAsync<T>(Func<T> action);
}
