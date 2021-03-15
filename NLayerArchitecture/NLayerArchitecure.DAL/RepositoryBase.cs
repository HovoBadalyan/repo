using Microsoft.EntityFrameworkCore;
using NLayerArchitecure.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLayerArchitecure.DAL
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly NORTHWNDContext Context;

        public RepositoryBase(NORTHWNDContext dbContext)
        {
            Context = dbContext;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);

        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }

        public T Get(int id)
        {
            var entity = Context.Set<T>().Find(id);
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = Context.Set<T>().ToArray();
            return entities;
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public bool Any(Func<T,bool> condition)
        {
            return Context.Set<T>().Any(condition);
        }
    }
}
