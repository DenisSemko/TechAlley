namespace Catalog.Domain.Entities;

[BsonCollection("CatalogWishlist")]
public sealed class CatalogWishlist : BaseEntity
{
    public List<CatalogItem> CatalogItems { get; private set; }
    public Guid BuyerId { get; private set; }
    
    public CatalogWishlist(Guid id, List<CatalogItem> catalogItems, Guid buyerId) : base(id)
    {
        CatalogItems = catalogItems;
        BuyerId = buyerId;
    }
}