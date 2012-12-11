using NHibernate;
using Spring.Transaction.Interceptor;
using Tuskr.Data.Entities;

namespace Tuskr.Data.NHibernate
{
    [Transaction()]
    public class TaskRepository : RepoBase<Task>
    {
        public TaskRepository(ISessionFactory sessionFactory) : base(sessionFactory)
        {
        }
    }

}