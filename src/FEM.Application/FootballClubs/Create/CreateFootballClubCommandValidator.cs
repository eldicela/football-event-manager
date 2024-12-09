
using FluentValidation;

namespace FEM.Application.FootballClubs.Create;

public class CreateFootballClubCommandValidator : AbstractValidator<CreateFootballClubCommand>
{
	public CreateFootballClubCommandValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name shouldn't be empty");
		RuleFor(x => x.Type).NotEmpty();

	}
}
