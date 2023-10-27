namespace Catalog.Application.Common.Helpers;

public class PagedList<T>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public List<T> Items { get; set; }
    
    public PagedList(int currentPage, int pageSize, int totalRecords, List<T> items)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        Items = new List<T>();
        Items.AddRange(items);
    }
}