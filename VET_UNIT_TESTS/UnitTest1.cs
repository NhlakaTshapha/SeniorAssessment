using Microsoft.VisualStudio.TestTools.UnitTesting;
using VET_CLINIC.Models;
using VET_CLINIC.Controllers;
using System.Web.Mvc;

namespace VET_UNIT_TESTS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Welcome() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }
    }
}
