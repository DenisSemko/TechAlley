namespace Ordering.Application.Features.Ordering.Commands.UpdateOrder;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("{Id} is required.")
            .NotNull();
        
        RuleFor(p => p.BuyerId)
            .NotEmpty().WithMessage("{BuyerId} is required.")
            .NotNull();

        RuleFor(p => p.TotalPrice)
            .NotEmpty().WithMessage("{TotalPrice} is required.")
            .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero."); 
    }
}