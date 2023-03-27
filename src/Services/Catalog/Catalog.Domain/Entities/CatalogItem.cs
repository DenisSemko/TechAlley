namespace Catalog.Domain.Entities;

public sealed class CatalogItem : BaseEntity
{
    public string Name { get; private set; }
	
    public string Description { get; private set; }
	
    public decimal Price { get; private set; }
		
    public string ImageFileName { get; private set; }
		
    public string ImageUri { get; private set; }
	
    public CatalogType CatalogType { get; private set; }

    public Guid CatalogTypeId { get; private set; }

    public CatalogBrand CatalogBrand { get; private set; }

    public Guid CatalogBrandId { get; private set; }

    public int Quantity { get; private set; }

    public CatalogItem(Guid id, string name, string description, string imageFileName, string imageUri, CatalogType catalogType, CatalogBrand catalogBrand, decimal price, int quantity) : base(id)
    {
	    Name = name;
	    Description = description;
	    ImageFileName = imageFileName;
	    ImageUri = imageUri;
	    CatalogType = catalogType;
	    CatalogBrand = catalogBrand;
	    Price = price;
	    CatalogTypeId = catalogType.Id;
	    CatalogBrandId = catalogBrand.Id;
	    Quantity = quantity;
    }
}
