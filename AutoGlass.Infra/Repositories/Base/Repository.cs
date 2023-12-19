using AutoGlass.Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoGlass.Infra.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SqlContext _sqlContext;

        public Repository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _sqlContext.Set<T>();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _sqlContext.Set<T>().Where(expression);
        }

        public T GetByCodigo(int codigo)
        {
            return _sqlContext.Set<T>().Find(codigo);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _sqlContext.Set<T>().Where(predicate).Any();
        }

        public void Create(T entity, bool save = true)
        {
            _sqlContext.Add(entity);

            if (save)
                Save();
        }

        public void CreateList(IEnumerable<T> entity, bool save = true)
        {
            _sqlContext.AddRange(entity);

            if (save)
                Save();
        }

        public void Update(T entity, bool save = true)
        {
            _sqlContext.Entry(entity).State = EntityState.Modified;

            if (save)
                Save();
        }

        public void UpdateList(IEnumerable<T> entities, bool save = true)
        {
            entities = entities.Select(x =>
            {
                _sqlContext.Entry(x).State = EntityState.Modified;
                return x;
            });

            if (save)
                Save();
        }

        public void Delete(T entity, bool save = true)
        {
            _sqlContext.Remove(entity);

            if (save)
                Save();
        }

        public void DeleteList(IEnumerable<T> entities, bool save = true)
        {
            _sqlContext.RemoveRange(entities);

            if (save)
                Save();
        }

        public void Save()
        {
            _sqlContext.SaveChanges();
        }

        public void RollBack()
        {
            var changedEntries = _sqlContext.ChangeTracker
                .Entries()
                .Where(x => x.State != EntityState.Unchanged)
                .ToList();
            
            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
