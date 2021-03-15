using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecure.Core.Abstractions.Repositories
{
    public interface IRepositoryBase<T>
        where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T Get(int id);
        void SaveChanges();
    }
}
