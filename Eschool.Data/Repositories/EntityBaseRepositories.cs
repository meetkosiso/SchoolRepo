using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Linq.Expressions;
using Eschool.Data.Abstract;
using Eschool.Model;

namespace Eschool.Data.Repositories
{
    public class EntityBaseRepositories<T> : IEntityBaseRepositories<T> where T : class, IEntityBase, new()
    {
        private EschoolContext _eschoolcontext;

        public EntityBaseRepositories(EschoolContext eschoolcontext)
        {
            _eschoolcontext = eschoolcontext;
        }

        public virtual void Add(T Entity)
        {
            _eschoolcontext.Set<T>().Add(Entity);
        }

        public virtual IEnumerable<T> AllProperties(params Expression<Func<T, object>>[] IncludeAllproperties)
        {
            IQueryable<T> getQuery = _eschoolcontext.Set<T>();
            foreach(var allproperty in IncludeAllproperties)
            {
                getQuery = getQuery.Include(allproperty);
            }

            return getQuery.AsEnumerable();
        }

        public virtual void Commit()
        {
            _eschoolcontext.SaveChanges();
        }

        public int Count()
        {
            return _eschoolcontext.Set<T>().Count();
        }

        public virtual void Delete(T Entity)
        {
            _eschoolcontext.Entry<T>(Entity).State = EntityState.Deleted;
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _eschoolcontext.Set<T>().Where(predicate);
            foreach(var entity in entities)
            {
                _eschoolcontext.Entry<T>(entity).State = EntityState.Deleted;
            }
        }

        public virtual IEnumerable<T> FetchAll()
        {
            return _eschoolcontext.Set<T>().AsEnumerable();
        }

        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _eschoolcontext.Set<T>().Where(predicate);
        }

        public T GetSingle(int id)
        {
            return _eschoolcontext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _eschoolcontext.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] Allproperties)
        {
            IQueryable<T> getQuery = _eschoolcontext.Set<T>();
            foreach(var allproperties in Allproperties)
            {
                getQuery = getQuery.Include(allproperties);
            }

            return getQuery.FirstOrDefault(predicate);
        }

        public virtual void Update(T Entity)
        {
            EntityEntry dbEntityEntry = _eschoolcontext.Entry<T>(Entity);
            dbEntityEntry.State = EntityState.Modified;
        }
    }
}
