namespace Catalog.UnitTests.Common;

public static class FakeData
{
    private static readonly CatalogType CatalogType =
        new (new Guid("9a1db939-69e1-4d49-9f3d-579938f599d5"), "FakeType");
    
    private static readonly CatalogBrand CatalogBrand =
        new (new Guid("9a1db939-69e1-4d49-9f3d-579938f599d5"), "FakeBrand");
    
    
    public static List<CatalogItem> FakeCatalogItems = new ()
    {
        new CatalogItem(new Guid("5ddc604b-e52e-4499-bb07-8b6801634863"), "Test Item",
            "Item", "", CatalogType, CatalogBrand, 12, 1000),
        new CatalogItem(new Guid("99f804b4-7579-4ead-81ac-c0cf7b885df9"), "Test Item2",
            "Item2", "", CatalogType, CatalogBrand, 10, 500)
    };

    public static readonly CatalogItemDto InvalidCatalogItemDto = new ()
    {
        Name = "Test Invalid Item",
        Description = "Invalid Item",
        Price = 0,
        ImageFileName = "fake.png",
        CatalogType = "",
        CatalogBrand = "",
        Quantity = 0
    };

    public static CatalogItem SingleFakeCatalogItem = new (new Guid("83775d25-ea44-4a95-b2c2-6fed4dc8d6a6"), "Test Item3",
        "Item3", "", CatalogType, CatalogBrand, 90.0m, 2000);
}