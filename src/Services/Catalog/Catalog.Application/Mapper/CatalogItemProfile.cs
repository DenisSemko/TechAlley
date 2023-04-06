namespace Catalog.Application.Mapper;

public class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<IReadOnlyList<CatalogItem>, List<CatalogItemDto>>()
            .ConvertUsing(new CatalogItemsToCatalogItemsDto());
        CreateMap<CatalogItem, CatalogItemDto>()
            .ConvertUsing(new CatalogItemToCatalogItemDto());
    }
}