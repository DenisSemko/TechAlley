namespace Catalog.Application.Mapper.Converters;

public static class CatalogItemDtoToCatalogItem
{
    public static CatalogItem Convert(CatalogItemDto source, CatalogTypeDto catalogType, CatalogBrandDto catalogBrand)
    {
        return new CatalogItem(
            source.Id, 
            source.Name, 
            source.Description, 
            source.ImageUri.Substring((source.ImageUri.LastIndexOf("/") + 1)),
            source.ImageUri, 
            new CatalogType(catalogType.Id, catalogType.Type), 
            new CatalogBrand(catalogBrand.Id, catalogBrand.Brand), 
            source.Price, 
            source.Quantity
        );
    }
}