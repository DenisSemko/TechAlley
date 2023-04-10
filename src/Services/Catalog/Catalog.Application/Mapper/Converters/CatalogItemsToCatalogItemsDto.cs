using NotImplementedException = System.NotImplementedException;

namespace Catalog.Application.Mapper.Converters;

public class CatalogItemsToCatalogItemsDto : ITypeConverter<IReadOnlyList<CatalogItem>, List<CatalogItemDto>>
{
    public List<CatalogItemDto> Convert(IReadOnlyList<CatalogItem> source, List<CatalogItemDto> destination, ResolutionContext context)
    {
        return source.Select(catalogItem => new CatalogItemDto()
        {
            Id = catalogItem.Id,
            Name = catalogItem.Name,
            Description = catalogItem.Description,
            Price = catalogItem.Price,
            CatalogBrand = catalogItem.CatalogBrand.Brand,
            CatalogType = catalogItem.CatalogType.Type,
            ImageUri = catalogItem.ImageUri,
            Quantity = catalogItem.Quantity
        }).ToList();
    }
}