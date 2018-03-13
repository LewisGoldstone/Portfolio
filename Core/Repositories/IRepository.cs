using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
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
        /// Generic function to return matching records - not soft-deleted
        /// </summary>
        /// <param name="predicate">lamba expression</param>
        /// <param name="orderBy">order by query</param>
        /// <returns>List<Entity></returns>
        List<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

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
