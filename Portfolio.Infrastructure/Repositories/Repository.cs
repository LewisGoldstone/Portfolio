using Portfolio.Domain;
using Portfolio.Domain.Extensions;
using Portfolio.Domain.Models;
using Portfolio.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.Infrastructure.Repositories
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

        private IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false)
        {
            var query = dbSet.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);

            if (includeDeleted == false)
                query = query.Where(i => i.IsDeleted == false);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false)
        {
            return this.GetQueryable(predicate, orderBy, includeDeleted).ToList();
        }

        public PagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate, int page, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false)
        {
            return this.GetQueryable(predicate, orderBy, includeDeleted).ToPagedList(page, pageSize);
        }

        public List<TEntity> GetAll(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false)
        {
            return this.GetQueryable(null, orderBy, includeDeleted).ToList();
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
