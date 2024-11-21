

using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class GoalsRepository : IGoalRepository
{
    private readonly DbSet<Goal> _dbSet;

    public GoalsRepository(FEMDbContext context)
    {
        _dbSet = context.Set<Goal>();
    }

    public async Task Add(Goal goal)
    {
        await _dbSet.AddAsync(goal);
    }

    public async Task<Goal> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id) ?? throw new Exception($"Goal with id: {id} doesn't exists");
    }
}
