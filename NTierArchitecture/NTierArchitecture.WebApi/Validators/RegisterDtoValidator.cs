using FluentValidation;
using NTierArchitecture.WebApi.DTOs;

namespace NTierArchitecture.WebApi.Validators;

public sealed class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(p=> p.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(p=> p.Name).NotNull().WithMessage("Name is required");
        RuleFor(p=> p.Name).MinimumLength(3).WithMessage("Name must be at least 3 characters");

        RuleFor(p => p.LastName).NotEmpty().WithMessage("LastName is required");
        RuleFor(p => p.LastName).NotNull().WithMessage("LastName is required");
        RuleFor(p => p.LastName).MinimumLength(3).WithMessage("LastName must be at least 3 characters");

        RuleFor(p => p.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(p => p.Email).NotNull().WithMessage("Email is required");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Email is not valid");

        RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required");
        RuleFor(p => p.Password).NotNull().WithMessage("Password is required");
        RuleFor(p => p.Password).MinimumLength(1).WithMessage("Password must be at least 1 characters");

    }
  
}
