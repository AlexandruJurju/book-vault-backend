using Ardalis.GuardClauses;
using Microsoft.EntityFrameworkCore;

namespace SharedKernel.Api;

public sealed record PagedList<T>(
    IReadOnlyList<T> Items,
    int PageIndex,
    int PageSize,
    long TotalCount
)
{
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;

    public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
    {
        int totalCount = await query.CountAsync();
        List<T> items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, page, pageSize, totalCount);
    }
}
