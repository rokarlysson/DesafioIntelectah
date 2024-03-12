using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, bool>> orderBy = null);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int Commit();
    }
}
