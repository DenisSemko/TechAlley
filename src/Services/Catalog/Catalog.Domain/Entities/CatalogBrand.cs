namespace Catalog.Domain.Entities;

public sealed class CatalogBrand : BaseEntity
{
    public string Brand { get; private set; }
    
    public CatalogBrand(Guid id, string brand) : base(id)
    {
        Brand = brand;
    }
}