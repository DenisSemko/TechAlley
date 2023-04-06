namespace Catalog.Application.Features.Catalog.Commands.DeleteCatalogItem;

public class DeleteCatalogItemCommand : IRequest
{
    public Guid Id { get; set; }
}