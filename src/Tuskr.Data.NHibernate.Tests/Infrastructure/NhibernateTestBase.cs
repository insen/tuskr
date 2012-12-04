using NHibernate;
using NHibernate.Stat;

namespace Tuskr.Data.NHibernate.Tests.Infrastructure
{
    public abstract class NhibernateTestBase
    {
        protected static ISessionFactory SessionFactory { get; private set; }
        protected IStatistics Statistics { get { return SessionFactory.Statistics;  } }

        static NhibernateTestBase()
        {
            SetSessionFactory();

            using (var session = CreateSession())
            using (var transaction = session.BeginTransaction())
            {
                //TestData.Create(session);
                transaction.Commit();
            }
        }

        private static void SetSessionFactory()
        {
            SessionFactory = NHSessionProvider.SessionFactory;
        }

        protected static ISession CreateSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}