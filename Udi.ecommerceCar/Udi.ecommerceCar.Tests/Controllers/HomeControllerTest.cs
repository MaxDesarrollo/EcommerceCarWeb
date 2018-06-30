// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeControllerTest.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Udi.ecommerceCar.Controllers;

    /// <summary>
    /// The home controller test.
    /// </summary>
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// The about.
        /// </summary>
        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            controller.Dispose();

            // Assert
            if (result != null)
            {
                Assert.AreEqual("Your application description page.", result.ViewBag.Message);
            }
        }

        /// <summary>
        /// The contact.
        /// </summary>
        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            controller.Dispose();

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// The index.
        /// </summary>
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;


            controller.Dispose();
            // Assert
            Assert.IsNotNull(result);
        }
    }
}