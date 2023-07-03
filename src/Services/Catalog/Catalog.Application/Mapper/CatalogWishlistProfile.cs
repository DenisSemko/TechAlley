namespace Catalog.Application.Mapper;

public class CatalogWishlistProfile : Profile
{
    public CatalogWishlistProfile()
    {
        CreateMap<CatalogWishlist, CatalogWishlistDto>()
            .ConvertUsing(new CatalogWishlistToCatalogWishlistDto());
        CreateMap<AddCatalogWishlistCommand, CatalogWishlistDto>()
            .ConvertUsing(new AddCatalogWishlistCommandToCatalogWishlistDto());
    }
}