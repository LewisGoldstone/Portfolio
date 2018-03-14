using Core;
using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class PagedListExtensions
    {
        /// <summary>
        /// Extends IQueryable to return as PagedList
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="query">IQueryable being extended</param>
        /// <param name="page">Page number NOT index</param>
        /// <param name="pageSize">Number of results needed returned</param>
        /// <returns>PagedList<TEntity></returns>
        public static PagedList<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> query, int page, int pageSize)
            where TEntity : PortfolioBase
        {
            return new PagedList<TEntity>(query, page, pageSize);
        }

        /// <summary>
        /// Extends IEnumerable to return as PagedList
        /// This is only used on an already queried PagedList object where we can pass in that instance's TotalCount and TotalPages
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="results">IEnumerable being extended</param>
        /// <param name="page">Page number NOT index</param>
        /// <param name="pageSize">Number of results needed returned</param>
        /// <param name="totalCount">PagedList<TEntity>.TotalCount</param>
        /// <param name="totalPages">PagedList<TEntity>.TotalPages</param>
        /// <returns>PagedList<TEntity></returns>
        public static PagedList<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> results, int page, int pageSize, int totalCount, int totalPages)
            where TEntity : PortfolioBase
        {
            return new PagedList<TEntity>(results, page, pageSize, totalCount, totalPages);
        }
    }
}
