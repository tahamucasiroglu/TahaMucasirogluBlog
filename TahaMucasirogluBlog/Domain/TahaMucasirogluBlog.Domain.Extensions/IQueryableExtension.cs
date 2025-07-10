using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace TahaMucasirogluBlog.Domain.Extensions
{
    static public class IQueryableExtension
    {
        static public IQueryable<T> ReverseCondition<T>(this IQueryable<T> query, bool reverse = false)
        {
            if (reverse)
            {
                return query.Reverse();
            }
            else
            {
                return query;
            }
        }


        static public IQueryable<T> WhereCondition<T>(this IQueryable<T> query, Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
            {
                return query;
            }
            else
            {
                return query.Where(filter);
            }
        }

        static public int CountCondition<T>(this IQueryable<T> query, Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
            {
                return query.Count();
            }
            else
            {
                return query.Count(filter);
            }
        }

        static public Task<int> CountAsyncCondition<T>(this IQueryable<T> query, Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null)
            {
                return query.CountAsync();
            }
            else
            {
                return query.CountAsync(filter);
            }
        }
    }
}
