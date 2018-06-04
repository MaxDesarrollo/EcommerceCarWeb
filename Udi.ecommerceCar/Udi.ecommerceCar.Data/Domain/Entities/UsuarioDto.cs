// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioDto.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    /// <summary>
    /// The usuario dto.
    /// </summary>
    public class UsuarioDto
    {
        /// <summary>
        /// Gets or sets the apellido.
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Gets or sets the nombre.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the usuario id.
        /// </summary>
        public int UsuarioId { get; set; }
    }
}