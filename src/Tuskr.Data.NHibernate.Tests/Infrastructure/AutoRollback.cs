using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace Tuskr.Data.NHibernate.Tests.Infrastructure
{
    public abstract class AutoRollback : NhibernateTestBase
    {
        protected ISession Session { get; private set; }
        protected ITransaction Transaction { get; private set; }

        [TestInitialize]
        public void SetUp()
        {
            BeforeSetUp();
            Session = SessionFactory.OpenSession();
            Transaction = Session.BeginTransaction();
            AfterSetUp();
        }

        protected virtual void BeforeSetUp() {}
        protected virtual void AfterSetUp() {}

        [TestCleanup]
        public void TearDown()
        {
            BeforeTearDown();
            if (Transaction != null) Transaction.Rollback(); 
            if (Session != null) Session.Dispose(); 
            AfterTearDown();
        }

        protected virtual void BeforeTearDown() {}
        protected virtual void AfterTearDown() {}

        /// <summary>
        /// Flushes all pending changes to the database.
        /// </summary>
        protected void Flush()
        {
            Session.Flush();
        }

        /// <summary>
        /// Removes all attached instances from the session, and also cancels all pending changes that haven't been flushed yet
        /// </summary>
        protected void Clear()
        {
            Session.Clear();
        }

        /// <summary>
        /// Flushes all pending changes to the database, and clears the session so no entities remain in the session cache.
        /// All entities that were attached to the session prior to calling this method will become detached instances
        /// </summary>
        protected void FlushAndClear()
        {
            Session.Flush();
            Session.Clear();
        }
    }
}