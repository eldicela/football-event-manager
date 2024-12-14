
using FEM.Application.Interfaces.Messaging;
using FEM.Domain.Entities;
using FEM.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FEM.Application.Cards.Create
{
    internal class CreateCardsListCommandHandler : ICommandHandler<CreateCardsListCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateCardsListCommandHandler(IServiceProvider serviceProvider)
        {
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
        public async Task<Unit> Handle(CreateCardsListCommand request, CancellationToken cancellationToken)
        {
            var cards = request.CardCommands.Select(x => new Card
            {
                MatchId = x.MatchId,
                TeamId = x.TeamId,
                PlayerId = x.PlayerId,
                IssuedMinute = x.IssuedMinute,
                Reason = x.Reason,
                Type = x.Type,
            }).ToList();

            await _unitOfWork.CardRepository.AddRangeAsync(cards);
            //await _unitOfWork.CommitAsync();
            _unitOfWork.Commit();

            return Unit.Value;
        }
    }
}
