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
            Servicios servicio = Get(pk);

            return new ServicioDto()
            {
                ////////////CAMBIAR PRECIO Y ESTADO
                Precio = decimal.Parse(servicio.Precio),
                Estado = bool.Parse(servicio.Estado),
                TipoServicioID = servicio.TipoServicioID
            };
        }

        public List<ServicioDto> ObtenerServicios()
        {
            return this.BuildQuery().Select(servicio => new ServicioDto()
            {
                ////////////CAMBIAR PRECIO Y ESTADO
                ServicioID = servicio.ServicioID,
                Precio = decimal.Parse(servicio.Precio),
                Estado = bool.Parse(servicio.Estado),
                TipoServicioID = servicio.TipoServicioID,
                TipoServicio = servicio.TipoServicio.Nombre
            }).ToList();
        }
    }
}
