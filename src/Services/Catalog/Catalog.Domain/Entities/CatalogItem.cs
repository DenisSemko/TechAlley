namespace Catalog.Domain.Entities;

[BsonCollection("CatalogItem")]
public sealed class CatalogItem : AggregateRoot
{
    public string Name { get; private set; }
	
    public string Description { get; private set; }
	
    public decimal Price { get; private set; }
		
    public string ImageFileName { get; private set; }
		
    public CatalogType CatalogType { get; private set; }

    public Guid CatalogTypeId { get; private set; }

    public CatalogBrand CatalogBrand { get; private set; }

    public Guid CatalogBrandId { get; private set; }

    public int Quantity { get; private set; }

    private CatalogItem(Guid id, string name, string description, string imageFileName, CatalogType catalogType, CatalogBrand catalogBrand, decimal price, int quantity) : base(id)
    {
	    Name = name;
	    Description = description;
	    ImageFileName = imageFileName;
	    CatalogType = catalogType;
	    CatalogBrand = catalogBrand;
	    Price = price;
	    CatalogTypeId = catalogType.Id;
	    CatalogBrandId = catalogBrand.Id;
	    Quantity = quantity;
    }

    public static CatalogItem Create(Guid id, string name, string description, string imageFileName, CatalogType catalogType, CatalogBrand catalogBrand, decimal price, int quantity)
    {
	    CatalogItem catalogItem = new(id, name, description, imageFileName, catalogType, catalogBrand,
		    price, quantity);
	    
	    catalogItem.RaiseDomainEvent(new CatalogItemCreatedEvent(catalogItem.Id));

	    return catalogItem;
    }
    
    public override bool Equals(object obj)
    {
	    if (obj == null || GetType() != obj.GetType())
	    {
		    return false;
	    }

	    var other = (CatalogItem)obj;

	    return Id == other.Id
	           && Name == other.Name
	           && Description == other.Description
	           && Price == other.Price
	           && ImageFileName == other.ImageFileName
	           && CatalogType == other.CatalogType
	           && CatalogBrand == other.CatalogBrand
	           && Quantity == other.Quantity;
    }
}
