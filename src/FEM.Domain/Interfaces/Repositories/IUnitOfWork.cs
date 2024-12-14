
using Microsoft.EntityFrameworkCore.Storage;

namespace FEM.Domain.Interfaces.Repositories;

public interface IUnitOfWork 
{
    #region Repositories
    IMatchRepositry MatchRepositry {  get; }
    IFootballClubRepository FootballClubRepository { get; }
    IMatchStatisticsRepository MatchStatisticsRepository { get; }
    IGoalRepository GoalRepository { get; }
    ICardRepository CardRepository { get; }
    IPlayersRepository PlayerRepository { get; }
    IFootballClubPlayerRepository FootballClubPlayerRepository { get; }
    #endregion

    IDbContextTransaction BeginTransaction();
    Task<IDbContextTransaction> BeginTransactionAsync();
    Task CommitAsync(CancellationToken cancellationToken = default);
    void Commit();
}
