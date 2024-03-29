namespace Catalog.Application.Mapper;

public class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<PagedList<CatalogItem>, PagedList<CatalogItemDto>>()
            .ConvertUsing(new CatalogItemsToCatalogItemsDto());
        CreateMap<CatalogItem, CatalogItemDto>()
            .ConvertUsing(new CatalogItemToCatalogItemDto());
        CreateMap<AddCatalogItemCommand, CatalogItemDto>()
            .ConvertUsing(new AddCatalogItemCommandToCatalogItemDto());
        CreateMap<CatalogType, CatalogTypeDto>()
            .ConvertUsing(new CatalogTypeToCatalogTypeDto());
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ConvertUsing(new CatalogBrandToCatalogBrandDto());
    }
}