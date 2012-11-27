using NHibernate;
using Tuskr.Data.Entities;

namespace Tuskr.Data.NHibernate
{
    public class TaskRepository : RepoBase<Task>
    {
        public TaskRepository(ISessionFactory session) : base(session)
        {
        }
    }

}