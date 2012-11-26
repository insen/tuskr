using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Tuskr.Data.Entities;

namespace Tuskr.Data.NHibernate.Tests
{
    [TestClass]
    public class NHibernateTests
    {
        [TestMethod]
        public void AddTaskIsOk()
        {
            var task = new Task {Name = "a task at last", StartDate = DateTime.Now.AddDays(1).Date};

            var nhSession = NHSessionHelper.OpenSession();
            ITransaction trans;

            using ( trans = nhSession.BeginTransaction())
            {
                var trepo = new TaskRepository(nhSession);
                trepo.Add(task);
                trans.Commit();
            }

        }
    }
}
