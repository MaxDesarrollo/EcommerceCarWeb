using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class ServicioRepositorio : EFRepositorio<Servicios>
    {
        public int GuardarServicio(ServicioDto servicio)
        {
            Servicios newServicio = new Servicios()
            {
                //////////////////////////CAMBIAR El precio y el Estado
                ServicioID = servicio.ServicioID,
                Precio = servicio.Precio.ToString(),
                Estado = servicio.Estado.ToString(),
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

                return this.BuildQuery()
                .Select(servicio => new ServicioDto()
                {
                    ////////////CAMBIAR PRECIO Y ESTADO
                    ServicioID = servicio.ServicioID,
                    Precio = servicio.Precio,
                    Estado = servicio.Estado,
                    TipoServicioID = servicio.TipoServicioID,
                    TipoServicio = servicio.TipoServicio.Nombre
                })
                .First(x => x.ServicioID == pk);
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
        public List<ServicioDto> ObtenerServicios(int page, int size)
        {
            return this.BuildQuery().Select(servicio => new ServicioDto()
            {
                ////////////CAMBIAR PRECIO Y ESTADO
                ServicioID = servicio.ServicioID,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
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
            return this.BuildQuery().Select(servicio => new ServicioDto()
            {
                ////////////CAMBIAR PRECIO Y ESTADO
                ServicioID = servicio.ServicioID,
                Precio = servicio.Precio,
                Estado = servicio.Estado,
                TipoServicioID = servicio.TipoServicioID,
                TipoServicio = servicio.TipoServicio.Nombre
            })
            .ToList();
        }
    }
}
