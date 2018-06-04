// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoProductoController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The tipo producto controller.
    /// </summary>
    public class TipoProductoController : Controller
    {
        /// <summary>
        /// The tipo producto servicio.
        /// </summary>
        private readonly TipoProductoServicio tipoProductoServicio = new TipoProductoServicio();

        /// <summary>
        /// The obtener tipos productos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerTiposProductosTodos()
        {
            try
            {
                var data = this.tipoProductoServicio.ObtenerTiposProductosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}