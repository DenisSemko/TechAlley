namespace Catalog.UnitTests.Common;

public class MockCatalogItem
{
    public string Name { get; set; }
	
    public string? Description { get; set; }
	
    public decimal Price { get; set; }

    public string? ImageUri { get; set; }
	
    public string CatalogType { get; set; }

    public string CatalogBrand { get; set; }

    public int Quantity { get; set; }
}