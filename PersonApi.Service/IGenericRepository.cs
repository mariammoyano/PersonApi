using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using PersonApi.Domain;

namespace PersonApi.Service
{
    public interface IGenericRepository<TEntity> where TEntity : DbEntity
    {
        public IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        public TEntity GetById(int id);
        public void Insert(TEntity entity);
        public void Update(TEntity entityToUpdate);
        public void Delete(int id);
        public void Delete(TEntity entityToDelete);
    }
}
