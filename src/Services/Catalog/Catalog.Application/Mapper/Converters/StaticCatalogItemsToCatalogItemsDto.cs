namespace Catalog.Application.Mapper.Converters;

public static class StaticCatalogItemsToCatalogItemsDto
{
    public static List<CatalogItemDto> Convert(IReadOnlyList<CatalogItem> source)
    {
        return source.Select(catalogItem => new CatalogItemDto()
        {
            Id = catalogItem.Id,
            Name = catalogItem.Name,
            Description = catalogItem.Description,
            Price = catalogItem.Price,
            CatalogBrand = catalogItem.CatalogBrand.Brand,
            CatalogType = catalogItem.CatalogType.Type,
            ImageFileName = catalogItem.ImageFileName,
            Quantity = catalogItem.Quantity
        }).ToList();
    }
}