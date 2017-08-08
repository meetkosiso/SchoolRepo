using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Eschool.Model;

namespace Eschool.Data.Abstract
{
   public interface IEntityBaseRepositories<T> where T:  class, IEntityBase, new()
    {
        IEnumerable<T> AllProperties(params Expression<Func<T, object>>[] Allproperties);
        IEnumerable<T> FetchAll();
        int Count();
        T GetSingle(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Allproperties);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        void Commit();
    }
}
