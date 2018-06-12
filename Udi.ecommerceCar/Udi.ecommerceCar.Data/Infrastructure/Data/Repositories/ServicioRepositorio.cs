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
                                           ServicioID = servicio.ServicioId, 
                                           Precio = servicio.Precio, 
                                           Estado = servicio.Estado, 
                                           Descripcion = servicio.Descripcion, 
                                           DescripcionCorta = servicio.DescripcionCorta, 
                                           ImagenID = servicio.ImagenId, 
                                           TipoServicioID = servicio.TipoServicioId
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
                                    ServicioId = servicio.ServicioID, 
                                    Precio = (decimal)servicio.Precio, 
                                    Estado = (bool)servicio.Estado, 
                                    Descripcion = servicio.Descripcion, 
                                    DescripcionCorta = servicio.DescripcionCorta, 
                                    ImagenId = servicio.ImagenID, 
                                    TipoServicioId = servicio.TipoServicioID, 
                                    TipoServicio = servicio.TipoServicio.Nombre,
                                    VisibleMain = servicio.VisibleMain
                                })
                        .First(x => x.ServicioId == pk);
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
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<ServicioDto> ObtenerServicios(int page, int size)
        {
            return
                this.BuildQuery()
                    .Select(
                        servicio =>
                        new ServicioDto()
                            {
                                ServicioId = servicio.ServicioID, 
                                Precio = (decimal)servicio.Precio, 
                                Estado = (bool)servicio.Estado, 
                                Descripcion = servicio.Descripcion, 
                                DescripcionCorta = servicio.DescripcionCorta, 
                                ImagenId = servicio.ImagenID, 
                                TipoServicioId = servicio.TipoServicioID, 
                                TipoServicio = servicio.TipoServicio.Nombre,
                                VisibleMain = servicio.VisibleMain
                            })
                    .OrderBy(x => x.ServicioId)
                    .Skip(page * size)
                    .Take(size)
                    .ToList();
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
            return
                this.BuildQuery()
                    .Select(
                        servicio =>
                        new ServicioDto()
                            {
                                ServicioId = servicio.ServicioID, 
                                Precio = (decimal)servicio.Precio, 
                                Estado = (bool)servicio.Estado, 
                                Descripcion = servicio.Descripcion, 
                                DescripcionCorta = servicio.DescripcionCorta, 
                                ImagenId = servicio.ImagenID, 
                                TipoServicioId = servicio.TipoServicioID, 
                                TipoServicio = servicio.TipoServicio.Nombre
                            })
                    .ToList();
        }

        public bool MarcarPrincipalServicio(int id)
        {
            var servicio = this.Get(id);

            if (servicio.VisibleMain == null)
            {
                servicio.VisibleMain = false;
            }

            servicio.VisibleMain = !servicio.VisibleMain;

            this.SaveChanges();

            return (bool)servicio.VisibleMain;
        }

        public List<ServicioDto> ObtenerServiciosPrincipales()
        {
            return
                this.BuildQuery()
                    .Where(x => x.VisibleMain == true)
                    .Select(
                        servicio =>
                        new ServicioDto()
                        {
                            ServicioId = servicio.ServicioID,
                            Precio = (decimal)servicio.Precio,
                            Estado = (bool)servicio.Estado,
                            Descripcion = servicio.Descripcion,
                            DescripcionCorta = servicio.DescripcionCorta,
                            ImagenId = servicio.ImagenID,
                            TipoServicioId = servicio.TipoServicioID,
                            TipoServicio = servicio.TipoServicio.Nombre
                        })
                    .ToList();
        }
    }
}