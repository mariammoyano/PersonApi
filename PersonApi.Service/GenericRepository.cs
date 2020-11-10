using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonApi.Domain;

namespace PersonApi.Service
{
    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal PersonContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(PersonContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList<TEntity>();
        }

        IEnumerable<TEntity> IGenericRepository<TEntity>.Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Delete(int id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            //TODO ask about attach
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        //TODO does this go on unit of work?
        //public virtual void Save()
        //{
        //    context.SaveChanges();
        //}
    }
}
