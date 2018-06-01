// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModeloDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    using System;

    /// <summary>
    /// The modelo dto.
    /// </summary>
    internal class ModeloDto
    {
        /// <summary>
        /// Gets or sets the cantidad puertas.
        /// </summary>
        private int CantidadPuertas { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether estado.
        /// </summary>
        private bool Estado { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether habilitado test drive.
        /// </summary>
        private bool HabilitadoTestDrive { get; set; }

        /// <summary>
        /// Gets or sets the marca id.
        /// </summary>
        private int MarcaID { get; set; }

        /// <summary>
        /// Gets or sets the nombre modelo.
        /// </summary>
        private string NombreModelo { get; set; }

        /// <summary>
        /// Gets or sets the tipo caja id.
        /// </summary>
        private int TipoCajaID { get; set; }

        /// <summary>
        /// Gets or sets the tipo vehiculo id.
        /// </summary>
        private int TipoVehiculoID { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo id.
        /// </summary>
        private int VehiculoID { get; set; }
    }
}