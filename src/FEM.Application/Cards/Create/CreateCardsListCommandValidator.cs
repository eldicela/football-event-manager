

using FluentValidation;

namespace FEM.Application.Cards.Create
{
    public class CreateCardsListCommandValidator : AbstractValidator<CreateCardsListCommand>
    {
        public CreateCardsListCommandValidator()
        {
            RuleForEach(x => x.CardCommands).SetValidator(new CreateCardCommandValidator());
        }
    }
}
