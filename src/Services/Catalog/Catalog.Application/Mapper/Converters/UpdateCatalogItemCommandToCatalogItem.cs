namespace Catalog.Application.Mapper.Converters;

public static class UpdateCatalogItemCommandToCatalogItem
{
    public static CatalogItem Convert(UpdateCatalogItemCommand source, CatalogType catalogType, CatalogBrand catalogBrand)
    {
        return new CatalogItem(
            source.Id,
            source.Name, 
            source.Description, 
            source.ImageFileName,
            catalogType,
            catalogBrand,
            source.Price,
            source.Quantity);
    }
}