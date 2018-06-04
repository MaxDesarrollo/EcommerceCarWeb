// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoServicioRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The tipo servicio repositorio.
    /// </summary>
    internal class TipoServicioRepositorio : EFRepositorio<TipoServicio>
    {
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
            return
                this.BuildQuery()
                    .Select(
                        tipoServ => new TipoServicioDto()
                        {
                            TipoServicioId = tipoServ.TipoServicioID, Nombre = tipoServ.Nombre
                        })
                    .ToList();
        }
    }
}