namespace Catalog.Application.Mapper.Converters;

public class CatalogItemToCatalogItemDto : ITypeConverter<CatalogItem, CatalogItemDto>
{
    public CatalogItemDto Convert(CatalogItem source, CatalogItemDto destination, ResolutionContext context)
    {
        return new CatalogItemDto()
        {
            Id = source.Id,
            Name = source.Name,
            Description = source.Description,
            Price = source.Price,
            CatalogBrand = source.CatalogBrand.Brand,
            CatalogType = source.CatalogType.Type,
            ImageUri = source.ImageUri,
            Quantity = source.Quantity
        };
    }
}