
using FEM.Domain.Interfaces.Repositories;
using FEM.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace FEM.Infrastructure.Data
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FEMDbContext _context;
        public UnitOfWork(FEMDbContext context)
        {
            _context = context;
        }

        private IMatchRepositry _matchRepositry;
        public IMatchRepositry MatchRepositry
        {
            get
            {
                _matchRepositry ??= new MatchesRepositories(_context);
                return _matchRepositry;
            }
        }

        private IFootballClubRepository _footballClubRepository;
        public IFootballClubRepository FootballClubRepository
        {
            get
            {
                _footballClubRepository ??= new FootballClubRepository(_context);
                return _footballClubRepository;
            }
        }

        private IMatchStatisticsRepository _matchStatisticsRepository;
        public IMatchStatisticsRepository MatchStatisticsRepository
        {
            get
            {
                _matchStatisticsRepository ??= new MatchStatisticsRepository(_context);
                return _matchStatisticsRepository;
            }
        }

        private IGoalRepository _goalRepository;
        public IGoalRepository GoalRepository
        {
            get
            {
                _goalRepository ??= new GoalsRepository(_context);
                return _goalRepository;
            }
        }

        private ICardRepository _cardRepository;
        public ICardRepository CardRepository
        {
            get
            {
                _cardRepository ??= new CardRepository(_context);
                return _cardRepository;
            }
        }

        private IPlayersRepository _playersRepository;
        public IPlayersRepository PlayerRepository
        {
            get
            {
                _playersRepository ??= new PlayersRepositories(_context);
                return _playersRepository;
            }
        }

        private IFootballClubPlayerRepository _footballClubPlayerRepository;
        public IFootballClubPlayerRepository FootballClubPlayerRepository
        {
            get
            {
                _footballClubPlayerRepository ??= new FutballClubPlayerRepository(_context);
                return _footballClubPlayerRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
