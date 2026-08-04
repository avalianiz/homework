using FluentValidation;
using homework17.Models;

namespace homework17.Validators;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(person => person.FirstName)
            .NotEmpty().WithMessage("First name is required")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters");
        
        RuleFor(person => person.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters");
        
        RuleFor(person => person.JobPosition)
            .NotEmpty().WithMessage("job position is required")
            .MaximumLength(50).WithMessage("job position cannot exceed 50 characters");
        
        RuleFor(person => person.CreateDate)
            .NotEmpty().WithMessage("Create date is required")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Create date cannot be in the future");
        
        RuleFor(person => person.Salary)
            .InclusiveBetween(0,10000).WithMessage("Salary must be between 0 and 10000");

        RuleFor(person => person.WorkExperience)
            .NotEmpty().WithMessage("work experience can not be empty");

        RuleFor(person => person.PersonAddress.Country)
            .NotEmpty().WithMessage("Country is required");
        
        RuleFor(person => person.PersonAddress.City)
            .NotEmpty().WithMessage("City is required");
        
        RuleFor(person => person.PersonAddress.HomeNumber)
            .NotEmpty().WithMessage("HomeNumber is required");
    }
}