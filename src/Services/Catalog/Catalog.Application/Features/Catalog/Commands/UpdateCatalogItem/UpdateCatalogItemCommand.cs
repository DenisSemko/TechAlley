namespace Catalog.Application.Features.Catalog.Commands.UpdateCatalogItem;

public class UpdateCatalogItemCommand : IRequest<Unit>
{
	public Guid Id { get; set; }
	
    public string Name { get; set; }
	
    public string? Description { get; set; }
	
    public decimal Price { get; set; }

    public string? ImageUri { get; set; }
	
    public string CatalogType { get; set; }

    public string CatalogBrand { get; set; }

    public int Quantity { get; set; }
}