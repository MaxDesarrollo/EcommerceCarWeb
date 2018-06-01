// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The servicio dto.
    /// </summary>
    public class ServicioDto
    {
        /// <summary>
        /// Gets or sets a value indicating whether estado.
        /// </summary>
        public bool Estado { get; set; }
        
        /// <summary>
        /// Gets or sets the precio.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Gets or sets the servicio id.
        /// </summary>
        public int ServicioID { get; set; }

        /// <summary>
        /// Gets or sets the tipo servicio.
        /// </summary>
        public string TipoServicio { get; set; }

        /// <summary>
        /// Gets or sets the tipo servicio id.
        /// </summary>
        public int TipoServicioID { get; set; }
    }
}