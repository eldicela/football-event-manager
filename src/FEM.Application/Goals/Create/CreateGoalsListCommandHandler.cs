
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Goals.Create;

public class CreateGoalsListCommandHandler : ICommandHandler<CreateGoalsListCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateGoalsListCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<Unit> Handle(CreateGoalsListCommand request, CancellationToken cancellationToken)
    {
        var goals = request.GoalsCommands.Select(x => new Goal
        {
            MatchId = x.MatchId,
            TeamId = x.TeamId,
            PlayerId = x.PlayerId,
            Minute = x.Minute,
            Type = x.Type,
        }).ToList();

        await _unitOfWork.GoalRepository.AddRangeAsync(goals);
        //await _unitOfWork.CommitAsync(cancellationToken);
        _unitOfWork.Commit();
        return Unit.Value;
    }
}
