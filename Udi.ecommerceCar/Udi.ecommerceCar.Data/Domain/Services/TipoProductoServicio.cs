// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoProductoServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The tipo producto servicio.
    /// </summary>
    public class TipoProductoServicio
    {
        /// <summary>
        /// The _tipo producto repositorio.
        /// </summary>
        private readonly TipoProductoRepositorio tipoProductoRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoProductoServicio"/> class.
        /// </summary>
        public TipoProductoServicio()
        {
            this.tipoProductoRepositorio = new TipoProductoRepositorio();
        }

        /// <summary>
        /// The obtener tipos productos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<TipoProductoDto> ObtenerTiposProductosTodos()
        {
            return this.tipoProductoRepositorio.ObtenerTiposProductosTodos();
        }
    }
}