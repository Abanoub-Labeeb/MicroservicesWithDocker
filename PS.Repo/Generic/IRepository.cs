using PS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PS.Repo
{
        public interface IRepository<T> where T : BaseEntity
        {
            IEnumerable<T> GetAll();
            IEnumerable<T> Find(Expression<Func<T,bool>> predicate);
            void Insert(T entity);
            void Update(T entity);
            void Delete(T entity);
            
        }
}
