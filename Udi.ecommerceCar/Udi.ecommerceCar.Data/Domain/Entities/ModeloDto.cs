// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModeloDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The modelo dto.
    /// </summary>
    public class ModeloDto
    {
        /// <summary>
        /// Gets or sets the cantidad puertas.
        /// </summary>
        public int CantidadPuertas { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether estado.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether habilitado test drive.
        /// </summary>
        public bool HabilitadoTestDrive { get; set; }

        /// <summary>
        /// Gets or sets the marca id.
        /// </summary>
        public int MarcaId { get; set; }

        /// <summary>
        /// Gets or sets the nombre modelo.
        /// </summary>
        public string NombreModelo { get; set; }

        /// <summary>
        /// Gets or sets the tipo caja id.
        /// </summary>
        public int TipoCajaId { get; set; }

        /// <summary>
        /// Gets or sets the tipo vehiculo id.
        /// </summary>
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo id.
        /// </summary>
        public int VehiculoId { get; set; }
    }
}