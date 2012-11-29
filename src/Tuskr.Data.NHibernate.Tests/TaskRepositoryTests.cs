using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuskr.Data.Entities;
using Tuskr.Data.NHibernate.Tests.Infrastructure;

namespace Tuskr.Data.NHibernate.Tests
{
    [TestClass]
    public class TaskRepositoryTests : Crud<Task,int>
    {
//        [TestMethod]
//        public void AddTaskIsOk()
//        {
//            var task = new Task {Name = "a task at last", StartDate = DateTime.Now.AddDays(1).Date};
//
//            var nhSessFac = NHSessionHelper.SessionFactory;
//            var nhSession = nhSessFac.OpenSession();
//
//            using (ITransaction trans = nhSession.BeginTransaction())
//            {
//                bool isOk;
//                try
//                {
//                    var trepo = new TaskRepository(nhSessFac);
//                    isOk = trepo.Add(task);
//                    if (isOk) trans.Commit();
//                }
//                catch (Exception)
//                {
//                    trans.Rollback();
//                }
//            }
//        }

        protected override Task BuildEntity()
        {
            return new Task {Name = "a task at last", StartDate = DateTime.Now.AddDays(1).Date};
        }

        protected override void ModifyEntity(Task entity)
        {
            entity.StartDate = entity.StartDate.AddDays(1).Date;
            entity.Description = entity.Description +
                                 string.Format("Modified with data - {0}{1}", entity.StartDate, Environment.NewLine);
        }

        protected override void AssertAreEqual(Task expectedEntity, Task actualEntity)
        {
            Assert.AreEqual(expectedEntity.Id, actualEntity.Id);
        }

        protected override void AssertValidId(Task entity)
        {
            Assert.IsTrue(entity.Id > 0);
        }
    }
}
