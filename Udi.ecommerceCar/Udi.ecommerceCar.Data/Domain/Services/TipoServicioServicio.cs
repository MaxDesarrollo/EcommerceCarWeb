// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoServicioServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The tipo servicio servicio.
    /// </summary>
    public class TipoServicioServicio
    {
        /// <summary>
        /// The _tipo servicio repositorio.
        /// </summary>
        private readonly TipoServicioRepositorio tipoServicioRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="TipoServicioServicio"/> class.
        /// </summary>
        public TipoServicioServicio()
        {
            this.tipoServicioRepositorio = new TipoServicioRepositorio();
        }

        /// <summary>
        /// The obtener tipos servicios todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<TipoServicioDto> ObtenerTiposServiciosTodos()
        {
            return this.tipoServicioRepositorio.ObtenerTiposServiciosTodos();
        }
    }
}