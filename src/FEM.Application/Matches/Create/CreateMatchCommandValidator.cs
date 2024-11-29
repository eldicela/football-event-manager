﻿

using FluentValidation;

namespace FEM.Application.Matches.Create;

public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
{
    public CreateMatchCommandValidator(IServiceProvider serviceProvider)
    {
        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date shouldn't be empty")
            .GreaterThan(DateTime.Now).WithMessage("Date and Time should be in the future");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Enter Valid Category a negative id isn't valid");

        RuleFor(x => x.Team1)
            .NotEmpty().WithMessage("TeamId shouldn't be empty");

        RuleFor(x => x.Team2)
           .NotEmpty().WithMessage("TeamId shouldn't be empty");


        //TO DO
        //Team1 id shouldn't be same as team 2 id
    }
}