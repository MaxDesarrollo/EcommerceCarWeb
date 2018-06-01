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
    internal class MarcaDto
    {
        /// <summary>
        /// Gets or sets the marca id.
        /// </summary>
        private int MarcaID { get; set; }

        /// <summary>
        /// Gets or sets the nombre marca.
        /// </summary>
        private string NombreMarca { get; set; }

        /// <summary>
        /// Gets or sets the pais origen.
        /// </summary>
        private string PaisOrigen { get; set; }
    }
}