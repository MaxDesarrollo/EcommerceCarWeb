// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The vehiculo servicio.
    /// </summary>
    public class VehiculoServicio
    {
        /// <summary>
        /// The _vehiculo repositorio.
        /// </summary>
        private readonly VehiculoRepositorio vehiculoRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="VehiculoServicio"/> class.
        /// </summary>
        public VehiculoServicio()
        {
            this.vehiculoRepositorio = new VehiculoRepositorio();
        }

        // public int GuardarVehiculo(VehiculoDto vehiculo)
        // {
        // return _vehiculoRepositorio.GuardarVehiculo(vehiculo);
        // }

        /// <summary>
        /// The obtener vehiculo.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="VehiculoDto"/>.
        /// </returns>
        public VehiculoDto ObtenerVehiculo(int pk)
        {
            return this.vehiculoRepositorio.ObtenerVehiculo(pk);
        }

        /// <summary>
        /// The obtener vehiculos.
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
        public List<VehiculoDto> ObtenerVehiculos(int? page, int? size)
        {
            var p = page ?? 0;
            var s = size ?? 10;

            return this.vehiculoRepositorio.ObtenerVehiculos(p, s);
        }

        /// <summary>
        /// The obtener vehiculos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VehiculoDto> ObtenerVehiculosTodos()
        {
            return this.vehiculoRepositorio.ObtenerVehiculosTodos();
        }

        public bool MarcarPrincipalVehiculo(int id)
        {
            return this.vehiculoRepositorio.MarcarPrincipalVehiculo(id);
        }

        public List<VehiculoDto> ObtenerVehiculosPrincipales()
        {
            return this.vehiculoRepositorio.ObtenerVehiculosPrincipales();
        }
    }
}