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
    public abstract class PortfolioBaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : PortfolioBase
    {
        internal DbContext context = new PortfolioContext();
        internal IDbSet<TEntity> dbSet;

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
