using FluentValidation;
using homework14.Models;

namespace homework14.Validators;

public class AddressValidator : AbstractValidator<Address>
{
    public AddressValidator()
    {
        RuleFor(address => address.Country)
            .NotEmpty()
            .WithMessage("Country is required")
            .MaximumLength(50)
            .WithMessage("Country cannot exceed 50 characters");
        
        
        RuleFor(address => address.City)
            .NotEmpty()
            .WithMessage("City is required")
            .MaximumLength(50)
            .WithMessage("City cannot exceed 50 characters");
        
        RuleFor(address => address.HomeNumber)
            .NotEmpty()
            .WithMessage("Home number is required.")
            .MaximumLength(20)
            .WithMessage("Home number must not exceed 20 characters.");
    }
}