namespace Catalog.Application.Mapper.Converters;

public class CatalogItemsToCatalogItemsDto : ITypeConverter<PagedList<CatalogItem>, PagedList<CatalogItemDto>>
{
    public PagedList<CatalogItemDto> Convert(PagedList<CatalogItem> source, PagedList<CatalogItemDto> destination, ResolutionContext context)
    {
        List<CatalogItemDto> catalogItemDtos = new();
        catalogItemDtos.AddRange(source.Items.Select(catalogItem => new CatalogItemDto()
        {
            Id = catalogItem.Id,
            Name = catalogItem.Name,
            Description = catalogItem.Description,
            Price = catalogItem.Price,
            CatalogBrand = catalogItem.CatalogBrand.Brand,
            CatalogType = catalogItem.CatalogType.Type,
            ImageFileName = catalogItem.ImageFileName,
            Quantity = catalogItem.Quantity
        }).ToList());
        return new PagedList<CatalogItemDto>(source.CurrentPage, source.PageSize, source.TotalRecords, catalogItemDtos);
    }
}