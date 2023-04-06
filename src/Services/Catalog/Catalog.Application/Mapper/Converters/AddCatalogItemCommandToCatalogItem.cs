namespace Catalog.Application.Mapper.Converters;

public static class AddCatalogItemCommandToCatalogItem
{
    public static CatalogItem Convert(AddCatalogItemCommand source, CatalogType catalogType, CatalogBrand catalogBrand)
    {
        return new CatalogItem(
            Guid.NewGuid(), 
            source.Name, 
            source.Description, 
            source.ImageUri.Substring((source.ImageUri.LastIndexOf("/") + 1)), 
            source.ImageUri,
            catalogType,
            catalogBrand,
            source.Price,
            source.Quantity);
    }
}