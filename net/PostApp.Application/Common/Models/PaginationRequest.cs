using System.ComponentModel.DataAnnotations;

namespace PostApp.Application.Common.Models;

public class PaginationRequest
{
    [Required]
    [Range(1, int.MaxValue)]
    public int PageSize { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int CurrentPage { get; set; }
}