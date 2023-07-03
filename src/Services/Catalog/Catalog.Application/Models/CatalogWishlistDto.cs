namespace Catalog.Application.Models;

public class CatalogWishlistDto
{
    public Guid Id { get; set;  }
    public Guid BuyerId { get; set; }
    public List<CatalogItemDto> CatalogItems { get; set; }
}