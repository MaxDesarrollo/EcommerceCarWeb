using System;
using System.Collections.Generic;
using System.Linq;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class ServicioRepositorio : EFRepositorio<Servicio>
    {
        public int GuardarServicio(ServicioDto servicio)
        {
            Servicio newServicio = new Servicio()
            {
                ServicioID = servicio.ServicioID,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
                Descripcion = servicio.Descripcion,
                DescripcionCorta = servicio.DescripcionCorta,
                ImagenID = servicio.ImagenID,
                TipoServicioID = servicio.TipoServicioID
            };

            Add(newServicio);
            SaveChanges();

            return newServicio.ServicioID;
        }

        public ServicioDto ObtenerServicio(int pk)
        {
            try
            {
                //Servicios servicio = Get(pk);

                return BuildQuery()
                .Select(servicio => new ServicioDto()
                {
                    ServicioID = servicio.ServicioID,
                    Precio = (decimal) servicio.Precio,
                    Estado = (bool) servicio.Estado,
                    Descripcion = servicio.Descripcion,
                    DescripcionCorta = servicio.DescripcionCorta,
                    ImagenID = servicio.ImagenID,
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
        public List<ServicioDto> ObtenerServicios(int page, int size)
        {
            return BuildQuery().Select(servicio => new ServicioDto()
            {
                ServicioID = servicio.ServicioID,
                Precio = (decimal) servicio.Precio,
                Estado = (bool) servicio.Estado,
                Descripcion = servicio.Descripcion,
                DescripcionCorta = servicio.DescripcionCorta,
                ImagenID = servicio.ImagenID,
                TipoServicioID = servicio.TipoServicioID,
                TipoServicio = servicio.TipoServicio.Nombre
            })
            .OrderBy(x => x.ServicioID)
            .Skip(page * size)
            .Take(size)
            .ToList();
        }

        public List<ServicioDto> ObtenerServiciosTodos()
        {
            return BuildQuery().Select(servicio => new ServicioDto()
            {
                ServicioID = servicio.ServicioID,
                Precio = (decimal) servicio.Precio,
                Estado = (bool) servicio.Estado,
                Descripcion = servicio.Descripcion,
                DescripcionCorta = servicio.DescripcionCorta,
                ImagenID = servicio.ImagenID,
                TipoServicioID = servicio.TipoServicioID,
                TipoServicio = servicio.TipoServicio.Nombre
            })
            .ToList();
        }
    }
}
