using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuskr.Data.Entities;
using Tuskr.Data.Infrastructure;
using Tuskr.Data.NHibernate;
using Tuskr.Web.Controllers;
using NSubstitute;
using Tuskr.Web.Models;

namespace Tuskr.Web.Tests.Controllers
{
    [TestClass]
    public class TaskControllerTest
    {

        [TestMethod]
        public void Can_Get_All_Tasks()
        {
            var repo = Substitute.For<IRepo<Task>>();
            repo.All().Returns(new[] {new Task{Name = "One"}}.AsQueryable());

            var tc = new TaskController(repo);
            var result = tc.All() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);

            var tasks = result.Model as IEnumerable<TaskModel>;
            Assert.IsNotNull(tasks);
            
            var taskModels = tasks as TaskModel[] ?? tasks.ToArray();
            Assert.IsTrue(taskModels.Any());
            Assert.IsTrue((taskModels.First().Name == "One"));
        }
    }
}