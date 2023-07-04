namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItemFromCatalogWishlist;

public class DeleteCatalogItemFromWishlistCommand : IRequest
{
    public Guid BuyerId { get; set; }
    public Guid CatalogItemId { get; set; }
}