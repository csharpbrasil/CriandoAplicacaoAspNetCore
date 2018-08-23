using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CriandoAplicacaoAspNetCore.Model.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CriandoAplicacaoAspNetCore.Data.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            this._context = context;
            this._dbSet = this._context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual void AddRange(List<TEntity> list)
        {
            list.ForEach(this.Add);
        }

        public virtual TEntity GetById(int id)
        {
            return this._dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "", bool noTracking = false)
        {
            IQueryable<TEntity> query = this._dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            foreach (var include in includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include);
            }

            if (noTracking)
                query = query.AsNoTracking();

            if (orderby != null)
            {
                return orderby(query).AsQueryable();
            }
            else
            {
                return query;
            }
        }

        public virtual void Update(TEntity entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = this._dbSet.Find(id);
            this._dbSet.Remove(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            this._dbSet.Attach(entity);
            this._dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> expression)
        {
            foreach (var entity in this._dbSet.Where(expression).AsEnumerable())
            {
                this._dbSet.Remove(entity);
            }
        }

        public virtual bool Any(int id)
        {
            return this._dbSet.Find(id) != null;
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return this._dbSet.Any(expression);
        }
    }
}
