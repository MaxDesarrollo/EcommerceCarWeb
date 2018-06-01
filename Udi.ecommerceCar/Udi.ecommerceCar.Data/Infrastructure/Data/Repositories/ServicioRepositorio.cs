// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The servicio repositorio.
    /// </summary>
    internal class ServicioRepositorio : EFRepositorio<Servicio>
    {
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
            Servicio newServicio = new Servicio()
                                       {
                                           ServicioID = servicio.ServicioID, 
                                           Precio = servicio.Precio, 
                                           Estado = servicio.Estado, 
                                           TipoServicioID = servicio.TipoServicioID
                                       };

            this.Add(newServicio);
            this.SaveChanges();

            return newServicio.ServicioID;
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
            try
            {
                // Servicios servicio = Get(pk);
                return
                    this.BuildQuery()
                        .Select(
                            servicio =>
                            new ServicioDto()
                                {
                                    ServicioID = servicio.ServicioID, 
                                    Precio = (decimal)servicio.Precio, 
                                    Estado = (bool)servicio.Estado, 
                                    TipoServicioID = servicio.TipoServicioID, 
                                    TipoServicio = servicio.TipoServicio.Nombre
                                })
                        .First(x => x.ServicioID == pk);
            }
            catch (Exception)
            {
                return null;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
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
        /// The <see cref="List"/>.
        /// </returns>
        public List<ServicioDto> ObtenerServicios(int page, int size)
        {
            return
                this.BuildQuery()
                    .Select(
                        servicio =>
                        new ServicioDto()
                            {
                                ServicioID = servicio.ServicioID, 
                                Precio = (decimal)servicio.Precio, 
                                Estado = (bool)servicio.Estado, 
                                TipoServicioID = servicio.TipoServicioID, 
                                TipoServicio = servicio.TipoServicio.Nombre
                            })
                    .OrderBy(x => x.ServicioID)
                    .Skip(page * size)
                    .Take(size)
                    .ToList();
        }

        /// <summary>
        /// The obtener servicios todos.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<ServicioDto> ObtenerServiciosTodos()
        {
            return
                this.BuildQuery()
                    .Select(
                        servicio =>
                        new ServicioDto()
                            {
                                ServicioID = servicio.ServicioID, 
                                Precio = (decimal)servicio.Precio, 
                                Estado = (bool)servicio.Estado, 
                                TipoServicioID = servicio.TipoServicioID, 
                                TipoServicio = servicio.TipoServicio.Nombre
                            })
                    .ToList();
        }
    }
}