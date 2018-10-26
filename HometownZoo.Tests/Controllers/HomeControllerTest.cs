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
        public void Index_ReturnNonNullViewResult()
        {
            // Arrange
            HomeController controller = new HomeController();

            //Act
            ViewResult result = controller.Index() as ViewResult;

            //Assert
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

        [TestMethod]
        public void About_ShouldHaveViewBagMessage()
        {
            // Arrange
            HomeController about = new HomeController();

            // Act
            ViewResult result = about.About() as ViewResult;

            string message = result.ViewBag.Message;

            //Assert
            Assert.IsNotNull(result.ViewBag.Message);
            Assert.AreNotEqual(string.Empty, message.Trim());
            //Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }
    }
}
