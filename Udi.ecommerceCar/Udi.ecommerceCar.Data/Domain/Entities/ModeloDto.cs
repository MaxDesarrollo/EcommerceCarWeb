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
        /// Obtiene o establece the cantidad puertas.
        /// </summary>
        public int CantidadPuertas { get; set; }

        /// <summary>
        /// Obtiene o establece a value indicating whether estado.
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Obtiene o establece a value indicating whether habilitado test drive.
        /// </summary>
        public bool HabilitadoTestDrive { get; set; }

        /// <summary>
        /// Obtiene o establece the marca id.
        /// </summary>
        public int MarcaId { get; set; }

        /// <summary>
        /// Obtiene o establece the nombre modelo.
        /// </summary>
        public string NombreModelo { get; set; }

        /// <summary>
        /// Obtiene o establece the tipo caja id.
        /// </summary>
        public int TipoCajaId { get; set; }

        /// <summary>
        /// Obtiene o establece the tipo vehiculo id.
        /// </summary>
        public int TipoVehiculoId { get; set; }

        /// <summary>
        /// Obtiene o establece the vehiculo id.
        /// </summary>
        public int VehiculoId { get; set; }
    }
}