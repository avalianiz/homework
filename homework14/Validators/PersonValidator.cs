using FluentValidation;
using FluentValidation.Validators;
using homework14.Models;

namespace homework14.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.CreateDate)
            .NotEmpty()
            .WithMessage("Create date is required.")
            .Must(createDate => createDate.Date <= DateTime.Today)
            .WithMessage("Create date can not be in the future.");
        
        RuleFor(person => person.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(50)
            .WithMessage("First name cannot be longer 50 characters.");
        
        RuleFor(person => person.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(50)
            .WithMessage("Last name cannot be longer 50 characters.");
        
        RuleFor(person => person.JobPosition)
            .NotEmpty()
            .WithMessage("Job position is required.")
            .MaximumLength(50)
            .WithMessage("Job position cannot be longer 50 characters.");
        
        RuleFor(person => person.Salary)
            .NotEmpty()
            .WithMessage("Salary is required.")
            .GreaterThan(0)
            .WithMessage("Salary cannot be negative.")
            .LessThanOrEqualTo(10000)
            .WithMessage("Salary cannot be greater than or equal to 10000.");

        RuleFor(person => person.WorkExperience)
            .NotEmpty()
            .WithMessage("Work experience is required.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("Work experience cannot be negative.");
            

        RuleFor(person => person.PersonAddress)
            .NotEmpty()
            .WithMessage("Address is required.");

        When(person => person.PersonAddress is not null, () =>
        {
            RuleFor(person => person.PersonAddress!)
                .SetValidator(new AddressValidator()); // validate address only after we know there is one
        });
    }
}