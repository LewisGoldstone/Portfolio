using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Domain.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : PortfolioBase
    {
        /// <summary>
        /// Generic function to insert record
        /// </summary>
        /// <param name="model">Entity</param>
        void Insert(TEntity model);

        /// <summary>
        /// Generic function to update record
        /// </summary>
        /// <param name="model">Entity</param>
        void Update(TEntity model);

        /// <summary>
        /// Generic function to soft delete record
        /// </summary>
        /// <param name="model">Entity</param>
        void Delete(TEntity model);

        /// <summary>
        /// Generic function to delete record
        /// </summary>
        /// <param name="model">Entity</param>
        void HardDelete(TEntity model);

        /// <summary>
        /// Generic function to return entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Given entity</returns>
        TEntity GetById(int id);

        /// <summary>
        /// Generic function to return matching records 
        /// </summary>
        /// <param name="predicate">lamba expression</param>
        /// <param name="orderBy">order by query</param>
        /// <param name="includeDeleted">bool to include soft deletions</param>
        /// <returns>List<Entity></returns>
        List<TEntity> Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false);

        /// <summary>
        /// Generic function to return matching records in a paged list
        /// </summary>
        /// <param name="predicate">lamba expression</param>
        /// <param name="page">Page number</param>
        /// <param name="pageSize">Number of record returned</param>
        /// <param name="orderBy">order by query</param>
        /// <param name="includeDeleted">bool to include soft deletions</param>
        /// <returns>List<Entity></returns>
        PagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false);

        /// <summary>
        /// Generic function to return all records
        /// </summary>
        /// <param name="orderBy">order by query</param>
        /// <param name="includeDeleted">bool to include soft deletions</param>
        /// <returns>List<Entity></returns>
        List<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false);

        /// <summary>
        /// Call to commit changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Dispose context
        /// </summary>
        void Dispose();
    }
}
