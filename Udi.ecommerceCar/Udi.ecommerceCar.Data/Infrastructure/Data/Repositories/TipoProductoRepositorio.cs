// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TipoProductoRepositorio.cs" company="MC Autoventas">
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
    /// The tipo producto repositorio.
    /// </summary>
    internal class TipoProductoRepositorio : EFRepositorio<TipoProducto>
    {
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
            return
                this.BuildQuery()
                    .Select(
                        tipoProd => new TipoProductoDto()
                        {
                            TipoProductoId = tipoProd.TipoProductoID, Nombre = tipoProd.Nombre
                        })
                    .ToList();
        }
    }
}