using System.Collections;

namespace Application.Common.Extensions;

public static class Pagination
{
    public static IQueryable ToPagination<T>(this IQueryable<T> source, int take, int skip)
    {
        return source.Skip(skip).Take(take);
    }
    
    public static IEnumerable ToPagination<T>(this IEnumerable<T> source, int take, int skip)
    {
        return source.Skip(skip).Take(take);
    }
}