// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The servicio servicio.
    /// </summary>
    public class ServicioServicio
    {
        /// <summary>
        /// The _servicio repositorio.
        /// </summary>
        private readonly ServicioRepositorio servicioRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioServicio"/> class.
        /// </summary>
        public ServicioServicio()
        {
            this.servicioRepositorio = new ServicioRepositorio();
        }

        /// <summary>
        /// The guardar servicio.
        /// </summary>
        /// <param name="servicio">
        /// The servicio.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GuardarServicio(ServicioDto servicio)
        {
            return this.servicioRepositorio.GuardarServicio(servicio);
        }

        /// <summary>
        /// The obtener servicio.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="ServicioDto"/>.
        /// </returns>
        public ServicioDto ObtenerServicio(int pk)
        {
            return this.servicioRepositorio.ObtenerServicio(pk);
        }

        /// <summary>
        /// The obtener servicios.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<ServicioDto> ObtenerServicios(int? page, int? size)
        {
            int p = page ?? 0;
            int s = size ?? 10;

            return this.servicioRepositorio.ObtenerServicios(p, s);
        }

        /// <summary>
        /// The obtener servicios todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<ServicioDto> ObtenerServiciosTodos()
        {
            return this.servicioRepositorio.ObtenerServiciosTodos();
        }
    }
}