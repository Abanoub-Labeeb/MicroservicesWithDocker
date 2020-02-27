using Microsoft.EntityFrameworkCore;
using PS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PS.Repo
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly DbContext context;
        protected DbSet<T> entityDBSet;
        string errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            this.context = context;
            entityDBSet  = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return entityDBSet.Include(t => t.Id).AsEnumerable();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return entityDBSet.Where(predicate).Include(t => t.Id).ToList();
        }
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entityDBSet.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entityDBSet.Remove(entity);
        }

    }
}
