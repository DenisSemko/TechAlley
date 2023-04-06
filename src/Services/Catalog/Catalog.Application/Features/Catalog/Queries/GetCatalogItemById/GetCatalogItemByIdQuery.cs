namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItemById;

public class GetCatalogItemByIdQuery : IRequest<CatalogItemDto>
{
    public Guid Id { get; set; }
}