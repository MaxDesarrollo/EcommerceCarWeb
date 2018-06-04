// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComunServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;

    /// <summary>
    /// The comun servicio.
    /// </summary>
    public class ComunServicio
    {
        /// <summary>
        /// The obtener dto from string.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <typeparam name="T">
        ///     Puede ser de cualquier clase de DTO generado en el proyecto
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     Si no puede devolver el DTO especificado tirará un error de Nulo
        /// </exception>
        public static T ObtenerDtoFromString<T>(string item)
        {
            try
            {
                if (string.IsNullOrEmpty(item))
                {
                    throw new ArgumentNullException("item");
                }

                using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(item)))
                {
                    var serializer = new DataContractJsonSerializer(typeof(T));
                    return (T)serializer.ReadObject(stream);
                }
            }
            catch (ArgumentNullException)
            {
                return (T)new object();
            }
        }
    }
}