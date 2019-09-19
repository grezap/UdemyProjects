using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Uplift.DataAccess.Data.Repository.IRepository;

namespace Uplift.DataAccess.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        #region Fields
        protected readonly DbContext _context;
        internal DbSet<T> dbSet;
        #endregion

        #region Constructor

        public Repository(DbContext context)
        {
            _context = context;

            this.dbSet = context.Set<T>();
        }

        #endregion

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null, 
            Func<System.Linq.IQueryable<T>, System.Linq.IOrderedQueryable<T>> orderBy = null, 
            string includeProperties = null
            )
        {
            IQueryable<T> query = dbSet;
            
            if (filter != null)
            {
                query = query.Where(filter);

            }

            //include properties is comma separated string list
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null, 
            string includeProperties = null
            )
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);

            }

            //include properties is comma separated string list
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityToRemove = dbSet.Find(id);
            dbSet.Remove(entityToRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
