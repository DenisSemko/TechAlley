namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogWishlist;

public class UpdateCatalogWishlistCommandValidator : AbstractValidator<AddCatalogWishlistCommand>
{
    public UpdateCatalogWishlistCommandValidator()
    {
        RuleFor(p => p.BuyerId)
            .NotEmpty().WithMessage("{BuyerId} is required.")
            .NotNull();

        RuleFor(p => p.CatalogItems)
            .NotEmpty().WithMessage("{CatalogItems} are required.");
    }
}