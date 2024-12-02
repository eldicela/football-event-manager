
using FEM.Domain.Common;
using FEM.Domain.Entities;
using FEM.Domain.Enums;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FEM.Infrastructure.Data.Repositories
{
    internal class MatchesRepositories : IMatchRepositry
    {
        private readonly DbSet<Match> _dbSet;
        private readonly DbSet<FootballClub> _clubs;
        public MatchesRepositories(FEMDbContext context)
        {
            _dbSet = context.Set<Match>();
            _clubs = context.Set<FootballClub>();
        }
        public async Task AddAsync(Match match)
        {
            await _dbSet.AddAsync(match);
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new Exception($"Match with id: {id} doesn't exists");
        }

        public async Task<IEnumerable<MatchWithClubs>> GetMatchesByTeamNameAsync(string teamName)
        {
            var query = (from matchh in _dbSet
                         join t1 in _clubs on matchh.Team1 equals t1.Id
                         join t2 in _clubs on matchh.Team2 equals t2.Id
                         select new MatchWithClubs
                         {
                             Id = matchh.Id,
                             CategoryId = matchh.CategoryId,
                             Date = matchh.Date,
                             Status = matchh.Status,
                             Team1 = new FootballClub
                             {
                                 Id = t1.Id,
                                 Name = t2.Name,
                                 Type = t1.Type,
                             },
                             Team2 = new FootballClub
                             {
                                 Id = t2.Id,
                                 Name = t1.Name,
                                 Type = t2.Type,
                             }
                         }
                      );


            query = query.Where(x => x.Team1.Name.ToLower().Contains(teamName.ToLower())
                        || x.Team2.Name.ToLower().Contains(teamName.ToLower()));

            return await query.ToListAsync();

        }

        public async Task<IEnumerable<MatchWithClubs>> GetMatchesFilterdAsync(MatchFilter filters)
        {
            var query = (from matchh in _dbSet
                         join t1 in _clubs on matchh.Team1 equals t1.Id
                         join t2 in _clubs on matchh.Team2 equals t2.Id
                         select new MatchWithClubs
                         {
                             Id = matchh.Id,
                             CategoryId = matchh.CategoryId,
                             Date = matchh.Date,
                             Status = matchh.Status,
                             Team1 = new FootballClub
                             {
                                 Id = t1.Id,
                                 Name = t2.Name,
                                 Type = t1.Type,
                             },
                             Team2 = new FootballClub
                             {
                                 Id = t2.Id,
                                 Name = t1.Name,
                                 Type = t2.Type,
                             }
                         }
                            );

            query = query.AsNoTracking();

            if (filters.TeamName != null)
                query = query.Where(x => x.Team1.Name.ToLower().Contains(filters.TeamName.ToLower())
                             || x.Team2.Name.ToLower().Contains(filters.TeamName.ToLower()));

            if (filters.Sort == SortType.ASCENDING)
                query = query.OrderBy(x => x.Date);
            if (filters.Sort == SortType.DESCENDING)
                query = query.OrderByDescending(x => x.Date);

            if (filters.Live)
            {
                query = query.Where(x => x.Status != MatchStatus.NOT_STARTED && x.Status != MatchStatus.FINNISHED && x.Date.Date == DateTime.Now.Date);
                return await query.ToListAsync();
            }

            if (filters.EndDate != null)
                query = query.Where(x => x.Date.Date >= filters.StartDate.Date && x.Date.Date <= filters.EndDate.Value.Date);
            else
                query = query.Where(x => x.Date.Date == filters.StartDate.Date);


            return await query.ToListAsync();
        }
    }
}
