

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories
{
    internal class FootballClubRepository : IFootballClubRepository
    {
        private readonly DbSet<FootballClub> _dbSet;

        public FootballClubRepository(FEMDbContext context)
        {
            _dbSet = context.Set<FootballClub>();
        }

        public async Task Add(FootballClub club)
        {
            await _dbSet.AddAsync(club);
        }

        public async Task<FootballClub> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception($"Football club with id: {id} doesn't exist");
        }
    }
}
