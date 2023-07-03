namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogWishlist;

public class UpdateCatalogWishlistCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public Guid BuyerId { get; set; }
    public List<CatalogItemDto> CatalogItems { get; set; }
}