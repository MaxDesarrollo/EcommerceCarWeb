// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Result.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// <summary>
//   The result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Tests
{
    /// <summary>
    /// The result.
    /// </summary>
    /// <typeparam name="T">
    /// Puede ser cualquier tipo de DTO que se necesite
    /// </typeparam>
    public class Result<T>
    {
        /// <summary>
        /// Gets or sets a value indicating whether success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the mensaje.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data { get; set; }
    }
}
