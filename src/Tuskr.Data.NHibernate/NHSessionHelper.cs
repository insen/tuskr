using NHibernate;
using NHibernate.Cfg;

namespace Tuskr.Data.NHibernate
{
    public class NHSessionHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new Configuration();
            configuration.Configure();
            return configuration.BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
