// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetalleVentaProductoServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The detalle venta producto servicio.
    /// </summary>
    public class DetalleVentaProductoServicio
    {
        /// <summary>
        /// The detalle venta producto repositorio.
        /// </summary>
        private readonly DetalleVentaProductoRepositorio detalleVentaProductoRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetalleVentaProductoServicio"/> class.
        /// </summary>
        public DetalleVentaProductoServicio()
        {
            this.detalleVentaProductoRepositorio = new DetalleVentaProductoRepositorio();
        }

        /// <summary>
        /// The obtener detalles ventas productos todos.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<DetalleVentaProductoDto> ObtenerDetallesVentasProductosTodos(int ventaProductoId)
        {
            return this.detalleVentaProductoRepositorio.ObtenerDetallesVentasProductosTodos(ventaProductoId);
        }
    }
}