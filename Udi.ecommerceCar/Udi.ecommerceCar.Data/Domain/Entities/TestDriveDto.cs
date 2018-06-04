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
    public class TestDriveDto
    {
        /// <summary>
        /// Gets or sets the fecha programada.
        /// </summary>
        public DateTime FechaProgramada { get; set; }

        /// <summary>
        /// Gets or sets the hora final.
        /// </summary>
        public DateTime HoraFinal { get; set; }

        /// <summary>
        /// Gets or sets the hora inicio.
        /// </summary>
        public DateTime HoraInicio { get; set; }

        /// <summary>
        /// Gets or sets the test drive id.
        /// </summary>
        public int TestDriveId { get; set; }

        /// <summary>
        /// Gets or sets the usuario id.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo id.
        /// </summary>
        public int VehiculoId { get; set; }
    }
}