using Microsoft.EntityFrameworkCore;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;

namespace PostApp.Persistence.Extensions;

public static class PaginationExtensions
{
    public static async Task<PaginationResponse<TView>> GetPagedAsync<TView, TViewKey>(this IQueryable<TView> content, PaginationRequest paginationRequest, CancellationToken cancellationToken) where TView : IEntityBase<TViewKey>
    {
        var totalItems = await content.CountAsync(cancellationToken);
        var lastPage = Convert.ToInt32(Math.Ceiling((double) totalItems / paginationRequest.PageSize));
        lastPage = lastPage == 0 ? 1 : lastPage;
        
        var pagedResponse = new PaginationResponse<TView>
        {
            Content = await content
                .Skip((paginationRequest.CurrentPage - 1) * paginationRequest.PageSize)
                .Take(paginationRequest.PageSize)
                .ToListAsync(cancellationToken),
            CurrentPage = Convert.ToInt32(Math.Min(lastPage, paginationRequest.CurrentPage)),
            PageSize = paginationRequest.PageSize,
            TotalItems = totalItems,
            LastPage = lastPage
        };
        
        return pagedResponse;
    }
}