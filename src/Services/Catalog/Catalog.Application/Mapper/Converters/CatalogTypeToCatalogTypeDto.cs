namespace Catalog.Application.Mapper.Converters;

public class CatalogTypeToCatalogTypeDto : ITypeConverter<CatalogType, CatalogTypeDto>
{
    public CatalogTypeDto Convert(CatalogType source, CatalogTypeDto destination, ResolutionContext context)
    {
        return new CatalogTypeDto()
        {
            Id = source.Id,
            Type = source.Type
        };
    }
}