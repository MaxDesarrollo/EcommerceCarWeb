// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    using System;

    /// <summary>
    /// The vehiculo dto.
    /// </summary>
    public class VehiculoDto
    {
        /// <summary>
        /// Gets or sets the año.
        /// </summary>
        public DateTime Año { get; set; }

        /// <summary>
        /// Gets or sets the cantidad disponible.
        /// </summary>
        public int? CantidadDisponible { get; set; }

        /// <summary>
        /// Gets or sets the cantidad puertas.
        /// </summary>
        public int? CantidadPuertas { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the estado.
        /// </summary>
        public bool? Estado { get; set; }

        /// <summary>
        /// Gets or sets the habilitado test drive.
        /// </summary>
        public bool? HabilitadoTestDrive { get; set; }

        /// <summary>
        /// Gets or sets the marca id.
        /// </summary>
        public int MarcaID { get; set; }

        /// <summary>
        /// Gets or sets the modelo id.
        /// </summary>
        public int? ModeloID { get; set; }

        /// <summary>
        /// Gets or sets the nombre marca.
        /// </summary>
        public string NombreMarca { get; set; }

        /// <summary>
        /// Gets or sets the nombre modelo.
        /// </summary>
        public string NombreModelo { get; set; }

        /// <summary>
        /// Gets or sets the nombre tipo caja.
        /// </summary>
        public string NombreTipoCaja { get; set; }

        /// <summary>
        /// Gets or sets the nombre tipo vehiculo.
        /// </summary>
        public string NombreTipoVehiculo { get; set; }

        /// <summary>
        /// Gets or sets the pais origen.
        /// </summary>
        public string PaisOrigen { get; set; }

        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        public decimal? Precio { get; set; }

        /// <summary>
        /// Gets or sets the tipo caja id.
        /// </summary>
        public int? TipoCajaID { get; set; }

        /// <summary>
        /// Gets or sets the tipo vehiculo id.
        /// </summary>
        public int? TipoVehiculoID { get; set; }

        /// <summary>
        /// Gets or sets the vehiculo id.
        /// </summary>
        public int VehiculoID { get; set; }
    }
}