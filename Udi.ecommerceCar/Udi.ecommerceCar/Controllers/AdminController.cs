// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The admin controller.
    /// </summary>
    public class AdminController : Controller
    {
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }
    }
}