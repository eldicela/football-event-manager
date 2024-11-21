﻿
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories;

internal class FutballClubPlayerRepository : IFootballClubPlayerRepository
{
    private readonly DbSet<FootballClubPlayer> _dbSet;
    public FutballClubPlayerRepository(FEMDbContext context)
    {
        _dbSet = context.Set<FootballClubPlayer>();
    }
    public async Task Add(FootballClubPlayer footballClubPlayer)
    {
        await _dbSet.AddAsync(footballClubPlayer);
    }
}
