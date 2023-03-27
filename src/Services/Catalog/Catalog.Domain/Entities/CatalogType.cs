namespace Catalog.Domain.Entities;

public sealed class CatalogType : BaseEntity
{
    public string Type { get; private set; }
    
    public CatalogType(Guid id, string type) : base(id)
    {
        Type = type;
    }
}