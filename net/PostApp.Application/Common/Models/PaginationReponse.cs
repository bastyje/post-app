namespace PostApp.Application.Common.Models;

public class PaginationResponse<T>
{
    public List<T> Content { get; set; }
    public int TotalItems { get; set; }
    public int LastPage { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
}