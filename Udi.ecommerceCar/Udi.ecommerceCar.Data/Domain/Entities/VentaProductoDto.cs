// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VentaProductoDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    using System;

    /// <summary>
    /// The venta producto dto.
    /// </summary>
    public class VentaProductoDto
    {
        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        public int? Estado { get; set; }

        /// <summary>
        /// Gets or sets the estado select.
        /// </summary>
        public string EstadoSelect { get; set; }

        /// <summary>
        /// Gets or sets the estado string.
        /// </summary>
        public string EstadoString { get; set; }

        /// <summary>
        /// Gets or sets the fecha.
        /// </summary>
        public DateTime? Fecha { get; set; }

        /// <summary>
        /// Gets or sets the hora.
        /// </summary>
        public TimeSpan? Hora { get; set; }

        /// <summary>
        /// Gets or sets the monto.
        /// </summary>
        public decimal? Monto { get; set; }

        /// <summary>
        /// Gets or sets the usuario.
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Gets or sets the usuario id.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Gets or sets the venta id.
        /// </summary>
        public int VentaId { get; set; }
    }
}