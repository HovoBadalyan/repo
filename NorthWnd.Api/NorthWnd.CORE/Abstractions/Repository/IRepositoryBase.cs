using System;
using System.Collections.Generic;


namespace NorthWnd.CORE.Abstractions.Repository
{
    public interface IRepositoryBase<T>
        where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetSingle(Func<T, bool> predicate);
        T Get(int id);
    }
}
