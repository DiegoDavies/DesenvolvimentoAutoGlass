using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AutoGlass.Domain.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T GetByCodigo(int codigo);
        bool Exists(Expression<Func<T, bool>> expression);
        void Create(T obj, bool save = true);
        void CreateList(IEnumerable<T> obj, bool save = true);
        void Update(T obj, bool save = true);
        void UpdateList(IEnumerable<T> obj, bool save = true);
        void Delete(T obj, bool save = true);
        void DeleteList(IEnumerable<T> obj, bool save = true);
        void Save();
        void RollBack();
    }
}
