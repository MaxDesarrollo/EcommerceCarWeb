// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetalleVentaProductoController.cs" company="MC Autoventas">
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
    /// The detalle venta producto controller.
    /// </summary>
    public class DetalleVentaProductoController : Controller
    {
        /// <summary>
        /// The detalle venta producto servicio.
        /// </summary>
        private readonly DetalleVentaProductoServicio detalleVentaProductoServicio = new DetalleVentaProductoServicio();

        /// <summary>
        /// The obtener detalles ventas productos todos.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerDetallesVentasProductosTodos(int ventaProductoId)
        {
            try
            {
                var data = this.detalleVentaProductoServicio.ObtenerDetallesVentasProductosTodos(ventaProductoId);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}