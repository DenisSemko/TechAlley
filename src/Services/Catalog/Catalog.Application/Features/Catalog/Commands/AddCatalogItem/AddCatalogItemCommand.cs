namespace Catalog.Application.Features.Catalog.Commands.AddCatalogItem;

public class AddCatalogItemCommand : IRequest<CatalogItemDto>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? ImageFileName { get; set; }
    public string CatalogType { get; set; }
    public string CatalogBrand { get; set; }
    public int Quantity { get; set; }
}  