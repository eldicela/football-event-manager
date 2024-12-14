

using FEM.Application.FootballClubPlayer.Service;
using FEM.Application.Interfaces.Services;
using FEM.Application.MatchStatistics.Service;
using FEM.Application.Players.Service;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application;

internal class ServicesManager : IServicesManager
{
    private static object _lock = new object();

    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWork _unitOfWork;
    public ServicesManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }


    private IFootballClubPlayerService _footballClubPlayersService;
    public IFootballClubPlayerService FootballClubPlayersService
    {
        get
        {
            _footballClubPlayersService ??= new FootballClubPlayerService(_serviceProvider);
            return _footballClubPlayersService;
        }
    }

    private IMatchStatisticsService _matchStatisticsService;
    public IMatchStatisticsService MatchStatisticsService
    {
        get
        {
            _matchStatisticsService ??= new MatchStatisticsService(_serviceProvider);
            return _matchStatisticsService;
        }
    }

    private IPlayersService _playersService;
    public IPlayersService PlayersService
    {
        get
        {
            _playersService ??= new PlayersService(_serviceProvider);
            return _playersService;
        }
    }

    public T WrapInTransaction<T>(Func<T> action)
    {
        lock (_lock)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            T result;
            try
            {
                result = action();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            return result;
        }
    }

    public async Task<T> WrapInTransactionAsync<T>(Func<T> action)
    {
        lock (_lock)
        {
            using var transaction =  _unitOfWork.BeginTransactionAsync().Result;

            T result;
            try
            {
                result = action();
                transaction.CommitAsync();
            }
            catch
            {
                transaction.RollbackAsync();
                throw;
            }
            return result;
        }
    }
}
