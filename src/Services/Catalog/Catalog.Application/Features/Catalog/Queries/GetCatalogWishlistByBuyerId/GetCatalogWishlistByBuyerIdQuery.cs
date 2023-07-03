namespace Catalog.Application.Features.Catalog.Queries.GetCatalogWishlistByBuyerId;

public class GetCatalogWishlistByBuyerIdQuery : IRequest<CatalogWishlistDto>
{
    public Guid BuyerId { get; set; }
}