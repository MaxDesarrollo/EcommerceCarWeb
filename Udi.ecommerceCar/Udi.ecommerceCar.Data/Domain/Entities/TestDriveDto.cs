// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDriveDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    using System;

    /// <summary>
    /// The test drive dto.
    /// </summary>
    internal class TestDriveDto
    {
        /// <summary>
        /// Gets or sets the fecha programada.
        /// </summary>
        private DateTime FechaProgramada { get; set; }

        /// <summary>
        /// Gets or sets the hora final.
        /// </summary>
        private DateTime HoraFinal { get; set; }

        /// <summary>
        /// Gets or sets the hora inicio.
        /// </summary>
        private DateTime HoraInicio { get; set; }

        /// <summary>
        /// Gets or sets the test drive id.
        /// </summary>
        private int TestDriveID { get; set; }

        /// <summary>
        /// Gets or sets the usuario id.
        /// </summary>
        private int UsuarioID { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo id.
        /// </summary>
        private int VehiculoID { get; set; }
    }
}