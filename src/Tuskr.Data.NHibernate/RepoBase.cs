using System.Collections.Generic;
using System.Linq;
using NHibernate;
using NHibernate.Linq;
using Tuskr.Data.Infrastructure;

namespace Tuskr.Data.NHibernate
{
    public class RepoBase<T> : IRepo<T> where T : class
    {
        private readonly ISession _session;

        public RepoBase(ISession session)
        {
            _session = session;
        }

        public bool Add(T entity)
        {
            _session.Save(entity);
            return true;
        }

        public bool Add(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                _session.Save(item);
            }
            return true;
        }

        public bool Update(T entity)
        {
            _session.Update(entity);
            return true;
        }

        public bool Delete(T entity)
        {
            _session.Delete(entity);
            return true;
        }

        public bool Delete(IEnumerable<T> entities)
        {
            foreach (T entity in entities)
            {
                _session.Delete(entity);
            }
            return true;
        }

        public T FindBy(int id)
        {
            return _session.Get<T>(id);
        }

        public IQueryable<T> All()
        {
            return _session.Query<T>();
        }

        public T FindBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return FilterBy(expression).Single();
        }

        public IQueryable<T> FilterBy(System.Linq.Expressions.Expression<System.Func<T, bool>> expression)
        {
            return All().Where(expression).AsQueryable();
        }
    }
}