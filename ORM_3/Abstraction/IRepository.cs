using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public interface IRepository<T> where T : class
    {
        T Add(T obj);
        T? Get(Expression<Func<T, bool>> exp);
        T? Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByFilter(Expression<Func<T, bool>> exp);
        T Update(T obj);
        bool Delete(T obj);
        bool SaveChanges();
    }
}