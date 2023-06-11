namespace Catalog.Application.Mapper;

public class CatalogItemProfile : Profile
{
    public CatalogItemProfile()
    {
        CreateMap<IReadOnlyList<CatalogItem>, List<CatalogItemDto>>()
            .ConvertUsing(new CatalogItemsToCatalogItemsDto());
        CreateMap<AddCatalogItemCommand, CatalogItemDto>()
            .ConvertUsing(new AddCatalogItemCommandToCatalogItemDto());
        CreateMap<CatalogType, CatalogTypeDto>()
            .ConvertUsing(new CatalogTypeToCatalogTypeDto());
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ConvertUsing(new CatalogBrandToCatalogBrandDto());
    }
}