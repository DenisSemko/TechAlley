namespace Catalog.Application.Common.Helpers;

public record GetCatalogItemsParams()
{
    public int PageNumber { get; set; } = 1;

    private int _pageSize = 5;
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > 100) ? 100 : value;
    }
}