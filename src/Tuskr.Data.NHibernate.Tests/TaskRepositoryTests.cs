using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Tuskr.Data.Entities;

namespace Tuskr.Data.NHibernate.Tests
{
    [TestClass]
    public class TaskRepositoryTests
    {
        [TestMethod]
        public void AddTaskIsOk()
        {
            var task = new Task {Name = "a task at last", StartDate = DateTime.Now.AddDays(1).Date};

            var nhSession = NHSessionHelper.OpenSession();

            using (ITransaction trans = nhSession.BeginTransaction())
            {
                bool isOk;
                try
                {
                    var trepo = new TaskRepository(nhSession);
                    isOk = trepo.Add(task);
                    if (isOk) trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                }
            }
        }
    }
}
