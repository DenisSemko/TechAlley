namespace Basket.Application.Features.Basket.Commands.UpdateBasketItems;

public class UpdateBasketItemsCommandValidator : AbstractValidator<UpdateBasketItemsCommand>
{
    public UpdateBasketItemsCommandValidator()
    {
        RuleFor(p => p.Items)
            .NotEmpty().WithMessage("Items list should not be empty.");
        
        RuleFor(p => p.BuyerId)
            .NotEmpty().WithMessage("{BuyerId} is required.")
            .NotNull();
    }
}