using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuskr.Data.Entities;

namespace Tuskr.Data.NHibernate.Tests.Infrastructure
{
    public abstract class Crud<TEntity, TId> : AutoRollback 
        where TEntity : Entity<TId> 
    {
        [TestMethod]
        public void Can_Read()
        {
            Session.CreateCriteria<TEntity>().SetMaxResults(1).List();
        }

        [TestMethod]
        public void Can_Create()
        {
            var entity = BuildEntity();
            InsertEntity(entity);
            Session.Evict(entity);

            var reloadedEntity = Session.Get<TEntity>(entity.Id);
            Assert.IsNotNull(reloadedEntity);
            AssertAreEqual(entity, reloadedEntity);
            AssertValidId(entity);
        }

        [TestMethod]
        public void Can_Update()
        {
            var entity = BuildEntity();
            InsertEntity(entity);
            ModifyEntity(entity);
            Session.Flush();
            Session.Evict(entity);

            var reloadedEntity = Session.Get<TEntity>(entity.Id);
            AssertAreEqual(entity, reloadedEntity);
        }

        [TestMethod]
        public void Can_Delete()
        {
            var entity = BuildEntity();
            InsertEntity(entity);
            DeleteEntity(entity);
            Assert.IsNull(Session.Get<TEntity>(entity.Id));
        }

        protected virtual void InsertEntity(TEntity entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        protected virtual void DeleteEntity(TEntity entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

        protected abstract TEntity BuildEntity();
        protected abstract void ModifyEntity(TEntity entity);
        protected abstract void AssertAreEqual(TEntity expectedEntity, TEntity actualEntity);
        protected abstract void AssertValidId(TEntity entity);
    }
}