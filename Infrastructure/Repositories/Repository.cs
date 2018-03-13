using Core.Models;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : PortfolioBase
    {
        private DbContext context = new PortfolioContext();
        private IDbSet<TEntity> dbSet;

        public Repository()
        {
            this.dbSet = context.Set<TEntity>();
        }

        public virtual void Insert(TEntity model)
        {
            dbSet.Add(model);
        }

        public virtual void Update(TEntity model)
        {
            context.Entry(model).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity model)
        {
            model.IsDeleted = true;
            context.Entry(model).State = EntityState.Modified;
        }

        public virtual void HardDelete(TEntity model)
        {
            dbSet.Remove(model);
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = dbSet.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);

            query = query.Where(i => i.IsDeleted == false);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
                context = null;
            }
        }
    }
}
