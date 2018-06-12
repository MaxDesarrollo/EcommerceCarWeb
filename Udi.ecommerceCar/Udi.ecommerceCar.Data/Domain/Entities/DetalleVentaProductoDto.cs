// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DetalleVentaProductoDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    using System;

    /// <summary>
    /// The detalle venta producto dto.
    /// </summary>
    public class DetalleVentaProductoDto
    {
        /// <summary>
        /// Obtiene o establece the cantidad.
        /// </summary>
        public int? Cantidad { get; set; }

        /// <summary>
        /// Obtiene o establece the detalle venta producto id.
        /// </summary>
        public int DetalleVentaProductoId { get; set; }

        /// <summary>
        /// Obtiene o establece the fecha.
        /// </summary>
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// Obtiene o establece the hora.
        /// </summary>
        public TimeSpan? Hora { get; set; }

        /// <summary>
        /// Obtiene o establece the precio.
        /// </summary>
        public decimal? Precio { get; set; }

        /// <summary>
        /// Obtiene o establece the producto.
        /// </summary>
        public string Producto { get; set; }

        /// <summary>
        /// Obtiene o establece the producto id.
        /// </summary>
        public int? ProductoId { get; set; }

        /// <summary>
        /// Obtiene o establece the venta producto id.
        /// </summary>
        public int? VentaProductoId { get; set; }
    }
}