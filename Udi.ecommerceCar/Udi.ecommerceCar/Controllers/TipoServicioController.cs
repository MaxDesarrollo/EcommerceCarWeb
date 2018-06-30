// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoServicioController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The tipo servicio controller.
    /// </summary>
    public class TipoServicioController : Controller
    {
        /// <summary>
        /// The tipo servicio servicio.
        /// </summary>
        private readonly TipoServicioServicio tipoServicioServicio = new TipoServicioServicio();

        /// <summary>
        /// The obtener tipos servicios todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerTiposServiciosTodos()
        {
            try
            {
                var data = this.tipoServicioServicio.ObtenerTiposServiciosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}