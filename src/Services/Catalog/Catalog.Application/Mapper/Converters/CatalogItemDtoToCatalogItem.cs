namespace Catalog.Application.Mapper.Converters;

public static class CatalogItemDtoToCatalogItem
{
    public static CatalogItem Convert(CatalogItemDto source, CatalogTypeDto catalogType, CatalogBrandDto catalogBrand)
    {
        CatalogItem catalogItem = CatalogItem.Create(
            source.Id, 
            source.Name, 
            source.Description, 
            source.ImageFileName,
            new CatalogType(catalogType.Id, catalogType.Type), 
            new CatalogBrand(catalogBrand.Id, catalogBrand.Brand),
            source.Price, 
            source.Quantity);
        return catalogItem;
    }
}