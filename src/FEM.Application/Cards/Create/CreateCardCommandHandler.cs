

using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Cards.Create;

internal class CreateCardCommandHandler : ICommandHandler<CreateCardCommand, int>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateCardCommandHandler(IServiceProvider serviceProvider)
    {
        _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    }

    public async Task<int> Handle(CreateCardCommand request, CancellationToken cancellationToken)
    {
        var card = new Card
        {
            MatchId = request.MatchId,
            TeamId = request.TeamId,
            PlayerId = request.PlayerId,
            IssuedMinute = request.IssuedMinute,
            Reason = request.Reason,
            Type = request.Type
        };
        await _unitOfWork.CardRepository.AddAsync(card);
        await _unitOfWork.CommitAsync(cancellationToken);
        return card.Id;
    }
}
