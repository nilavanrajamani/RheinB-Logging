using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EarlyInitializationSample.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);        
    }
}
