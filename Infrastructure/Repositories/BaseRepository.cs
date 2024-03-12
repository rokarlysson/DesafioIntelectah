using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly Contexto _contexto;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(Contexto contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>> orderBy = null)
        {
            var query = _dbSet.Where(where);

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy);
            }

            return query;
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public int Commit()
        {
            return _contexto.SaveChanges();
        }
    }
}
