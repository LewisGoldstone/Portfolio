using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Domain
{
    /// <summary>
    /// Collection that returns full pagination information
    /// </summary>
    /// <typeparam name="TEntity">Entity Type</typeparam>
    public class PagedList<TEntity> : List<TEntity>
        where TEntity : PortfolioBase
    {
        // Page number NOT index
        public int Page { get; private set; }

        // Number of records returned
        public int PageSize { get; private set; }

        // Total number of results query found
        public int TotalCount { get; private set; }

        // Total pages the results are divided between
        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return (Page > 1);
            }
        }
        public bool HasNextPage
        {
            get
            {
                return (Page < TotalPages);
            }
        }

        /// <summary>
        /// Expects IQueryable and paging information to return as PagedList
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="query">IQueryable being extended</param>
        /// <param name="page">Page number NOT index</param>
        /// <param name="pageSize">Number of results needed returned</param>
        public PagedList(IQueryable<TEntity> query, int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = query.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            if (HasOrderBy((MethodCallExpression)query.Expression) == false)
                query = query.OrderBy(i => i.Created);

            this.AddRange(query.Skip((Page - 1) * PageSize).Take(PageSize));
        }

        /// <summary>
        /// Expects IEnumerable and paging information to return as PagedList
        /// This is only used on an already queried PagedList object where we can pass in that instance's TotalCount and TotalPages
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <param name="query">IEnumerable being extended</param>
        /// <param name="page">Page number NOT index</param>
        /// <param name="pageSize">Number of results needed returned</param>
        /// <param name="totalCount">PagedList<TEntity>.TotalCount</param>
        /// <param name="totalPages">PagedList<TEntity>.TotalPages</param>
        public PagedList(IEnumerable<TEntity> results, int page, int pageSize, int totalCount, int totalPages)
        {
            Page = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPages = totalPages;

            this.AddRange(results);
        }

        private bool HasOrderBy(MethodCallExpression expression)
        {
            return expression.Method.Name == "OrderBy" || expression.Method.Name == "OrderByDescending";
        }
    }
}
