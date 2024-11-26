
using FEM.Domain.Entities;

namespace FEM.Domain.Interfaces.Repositories;

public interface IGoalRepository
{
    Task AddAsync(Goal goal);
    Task<Goal> GetByIdAsync(int id);
}
