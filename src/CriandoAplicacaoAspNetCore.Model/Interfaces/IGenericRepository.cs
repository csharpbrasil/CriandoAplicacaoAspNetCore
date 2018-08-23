using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CriandoAplicacaoAspNetCore.Model.Interfaces
{
	public interface IGenericRepository<TEntity> where TEntity : class
    {
		void Add(TEntity entity);
		void AddRange(List<TEntity> list);
		TEntity GetById(int id);
		IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, string includes = "", bool noTracking = false);
		void Update(TEntity entity);
		void Delete(int id);
		void Delete(TEntity entity);
		void Delete(Expression<Func<TEntity, bool>> expression);
		bool Any(int id);
		bool Any(Expression<Func<TEntity, bool>> expression);
    }
}
