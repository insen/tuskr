using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuskr.Web;
using Tuskr.Web.Controllers;

namespace Tuskr.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNull(result.ViewBag.Message);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
