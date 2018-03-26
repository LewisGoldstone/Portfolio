using Portfolio.Domain.Models;

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
        /// Call to commit changes
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Dispose context
        /// </summary>
        void Dispose();
    }
}
