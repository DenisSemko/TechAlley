namespace Catalog.Application.Common.Helpers;

public class PagedList<T> : List<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    
    public PagedList(List<T> items, int currentPage, int pageSize, int totalRecords)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
        AddRange(items);
    }
}