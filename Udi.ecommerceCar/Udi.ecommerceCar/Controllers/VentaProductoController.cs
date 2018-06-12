﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VentaProductoController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The venta producto controller.
    /// </summary>
    public class VentaProductoController : Controller
    {
        /// <summary>
        /// The venta producto servicio.
        /// </summary>
        private readonly VentaProductoServicio ventaProductoServicio = new VentaProductoServicio();

        /// <summary>
        /// The cambiar estado venta producto.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <param name="nuevoEstado">
        /// The nuevo estado.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            try
            {
                string nuevoEstadoSelect = this.ventaProductoServicio.CambiarEstadoVentaProducto(
                    ventaProductoId, 
                    nuevoEstado);

                return new JsonResult { Data = new { Success = true, Data = nuevoEstadoSelect } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The obtener ventas productos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVentasProductosTodos()
        {
            try
            {
                var data = this.ventaProductoServicio.ObtenerVentasProductosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}