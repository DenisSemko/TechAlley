namespace Catalog.Application.Mapper.Converters;

public class CatalogBrandToCatalogBrandDto : ITypeConverter<CatalogBrand, CatalogBrandDto>
{
    public CatalogBrandDto Convert(CatalogBrand source, CatalogBrandDto destination, ResolutionContext context)
    {
        return new CatalogBrandDto()
        {
            Id = source.Id,
            Brand = source.Brand
        };
    }
}