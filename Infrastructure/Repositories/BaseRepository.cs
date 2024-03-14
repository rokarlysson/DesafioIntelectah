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

        /// <summary>
        /// Consulta os dados utilizando uma expressão LINQ representando uma condição WHERE.
        /// Opcionalmente, pode-se passar uma segunda expressão LINQ representando um ORDER BY DESC
        /// </summary>
        /// <param name="where">condição</param>
        /// <param name="orderByDesc">ordenação</param>
        /// <returns>IQueryable&lt;TEntity&gt;</returns>
        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, bool>> orderByDesc = null)
        {
            var query = _dbSet.Where(where);

            if (orderByDesc != null)
            {
                query = query.OrderByDescending(orderByDesc);
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

        public void Insert(TEntity entity)
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
