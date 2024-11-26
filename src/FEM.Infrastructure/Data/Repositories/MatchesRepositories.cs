
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories
{
    internal class MatchesRepositories : IMatchRepositry
    {
        private readonly DbSet<Match> _dbSet;
        public MatchesRepositories(FEMDbContext context)
        {
            _dbSet = context.Set<Match>();
        }
        public async Task AddAsync(Match match)
        {
            await _dbSet.AddAsync(match);
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception($"Match with id: {id} doesn't exists"); 
        }
    }
}
