namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItemFromWishlist;

public class GetCatalogItemFromWishlistQuery : IRequest<bool>
{
    public Guid BuyerId { get; set; }
    public Guid CatalogItemId { get; set; }
}