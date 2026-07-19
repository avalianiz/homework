using FluentValidation;
using homework14.Models;

namespace homework14.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.CreateDate)
            .NotEmpty()
            .WithMessage("Create date is required.")
            .LessThanOrEqualTo(DateTime.Today)
            .WithMessage("Create date can not be in the future.");

    }
}