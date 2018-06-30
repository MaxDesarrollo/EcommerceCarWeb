// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExcepcionComercio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The excepcion comercio.
    /// </summary>
    [Serializable]
    public class ExcepcionComercio : Exception
    {
        /// <summary>
        /// The mensaje.
        /// </summary>
        private string mensaje = "Ocurrio un error en el controlador de area";

        /// <summary>
        /// Gets or sets the mensaje.
        /// </summary>
        public string Mensaje
        {
            get
            {
                return this.mensaje;
            }

            set
            {
                this.mensaje = value;
            }
        }

        /// <summary>
        /// The get object data.
        /// </summary>
        /// <param name="info">
        /// The info.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}