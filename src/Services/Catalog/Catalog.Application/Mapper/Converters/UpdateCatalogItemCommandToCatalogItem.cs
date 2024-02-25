namespace Catalog.Application.Mapper.Converters;

public static class UpdateCatalogItemCommandToCatalogItem
{
    public static CatalogItem Convert(UpdateCatalogItemCommand source, CatalogType catalogType, CatalogBrand catalogBrand)
    {
        CatalogItem catalogItem = CatalogItem.Create(
            source.Id, 
            source.Name, 
            source.Description, 
            source.ImageFileName,
            catalogType, 
            catalogBrand,
            source.Price, 
            source.Quantity);
        return catalogItem;
    }
}