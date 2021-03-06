﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoProductoDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The tipo producto dto.
    /// </summary>
    public class TipoProductoDto
    {
        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the tipo producto id.
        /// </summary>
        public int TipoProductoId { get; set; }
    }
}