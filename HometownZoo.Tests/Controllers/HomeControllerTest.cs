using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HometownZoo;
using HometownZoo.Controllers;

namespace HometownZoo.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index_ReturnsNonNullResult()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About_ReturnsNonNullViewResult()
        {
            // Arrange
            HomeController home = new HomeController();

            // Act
            ViewResult result = home.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        public void About_ShouldHaveViewBagMessage()
        {
            HomeController home = new HomeController();

            ViewResult result = home.About() as ViewResult;

            string message = result.ViewBag.Message;

            Assert.IsNotNull(message);
            Assert.AreNotEqual(string.Empty, message.Trim());
        }
    }
}
