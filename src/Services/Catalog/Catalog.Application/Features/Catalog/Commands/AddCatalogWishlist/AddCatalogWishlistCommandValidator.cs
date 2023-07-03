namespace Catalog.Application.Features.Catalog.Commands.AddCatalogWishlist;

public class AddCatalogWishlistCommandValidator : AbstractValidator<AddCatalogWishlistCommand>
{
    public AddCatalogWishlistCommandValidator()
    {
        RuleFor(p => p.BuyerId)
            .NotEmpty().WithMessage("{BuyerId} is required.")
            .NotNull();

        RuleFor(p => p.CatalogItems)
            .NotEmpty().WithMessage("{CatalogItems} are required.");
    }
}