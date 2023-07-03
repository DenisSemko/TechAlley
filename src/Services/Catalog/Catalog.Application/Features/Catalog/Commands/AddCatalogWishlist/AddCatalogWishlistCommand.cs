namespace Catalog.Application.Features.Catalog.Commands.AddCatalogWishlist;

public class AddCatalogWishlistCommand : IRequest<CatalogWishlistDto>
{
    public Guid BuyerId { get; set; }
    public List<CatalogItemDto> CatalogItems { get; set; }
}