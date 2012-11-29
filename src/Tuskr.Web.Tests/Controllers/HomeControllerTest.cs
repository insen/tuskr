using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuskr.Web.Controllers;

namespace Tuskr.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_Action_Returns_ViewResult_With_Message()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNull(result.ViewBag.Message);
        }

        [TestMethod]
        public void About_Action_Returns_ViewResult()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Contact_Action_Returns_ViewResult()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
