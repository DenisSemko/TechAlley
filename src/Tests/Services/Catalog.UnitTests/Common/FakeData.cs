namespace Catalog.UnitTests.Common;

public static class FakeData
{
    public static MockCatalogItem ConfigureInvalidData()
    {
        return new MockCatalogItem()
        {
            Name = "Test Item",
            Description = "Item2",
            Price = 0,
            ImageUri = "src/fake.png",
            CatalogType = "",
            CatalogBrand = "",
            Quantity = 0
        };
    }
    
    public static MockCatalogItem ConfigureData()
    {
        return new MockCatalogItem()
        {
            Name = "Item1",
            Description = "Item2",
            Price = 12,
            ImageUri = "src/fake.png",
            CatalogType = "Test Type",
            CatalogBrand = "Test Brand",
            Quantity = 12
        };
    }
}