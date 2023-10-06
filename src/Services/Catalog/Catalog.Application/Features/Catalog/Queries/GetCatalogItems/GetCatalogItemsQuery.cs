namespace Catalog.Application.Features.Catalog.Queries.GetCatalogItems;

public class GetCatalogItemsQuery : IRequest<PagedList<CatalogItemDto>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}