namespace Catalog.Application.Mapper.Converters;

public class AddCatalogItemCommandToCatalogItemDto : ITypeConverter<AddCatalogItemCommand, CatalogItemDto>
{
    public CatalogItemDto Convert(AddCatalogItemCommand source, CatalogItemDto destination, ResolutionContext context)
    {
        return new CatalogItemDto()
        {
            Id = Guid.NewGuid(), 
            Name = source.Name, 
            Description = source.Description, 
            ImageFileName = source.ImageFileName,
            CatalogType = source.CatalogType,
            CatalogBrand = source.CatalogBrand,
            Price = source.Price,
            Quantity = source.Quantity
        };
    }
}