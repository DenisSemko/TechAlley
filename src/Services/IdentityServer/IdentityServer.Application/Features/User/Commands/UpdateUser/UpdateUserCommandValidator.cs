namespace IdentityServer.Application.Features.User.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(IUnitOfWork unitOfWork)
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");
        
        RuleFor(p => p.Surname)
            .NotEmpty().WithMessage("{Name} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

        RuleFor(p => p.BirthDate)
            .NotEmpty().WithMessage("{BirthDate} is required.");

        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{Username} is required.")
            .NotNull();

        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("{Email} is required.")
            .NotNull();
    }
}