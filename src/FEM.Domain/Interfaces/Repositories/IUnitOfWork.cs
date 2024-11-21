
namespace FEM.Domain.Interfaces.Repositories;

public interface IUnitOfWork 
{
    #region Repositories
    IMatchRepositry MatchRepositry {  get; }
    IFootballClubRepository FootballClubRepository { get; }
    IMatchStatisticsRepository MatchStatisticsRepository { get; }
    IGoalRepository GoalRepository { get; }
    ICardRepository CardRepository { get; }
    #endregion

    Task CommitAsync(CancellationToken cancellationToken = default);
    void Commit();
}
