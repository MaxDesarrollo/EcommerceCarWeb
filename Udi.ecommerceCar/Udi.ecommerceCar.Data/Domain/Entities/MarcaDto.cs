// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarcaDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The marca dto.
    /// </summary>
    public class MarcaDto
    {
        /// <summary>
        /// Obtiene o establece the marca id.
        /// </summary>
        public int MarcaId { get; set; }

        /// <summary>
        /// Gets or sets the nombre marca.
        /// </summary>
        public string NombreMarca { get; set; }

        /// <summary>
        /// Gets or sets the pais origen.
        /// </summary>
        public string PaisOrigen { get; set; }
    }
}