using System.Collections.Generic;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class ServicioServicio
    {
        private readonly ServicioRepositorio _servicioRepositorio;

        public ServicioServicio()
        {
            this._servicioRepositorio = new ServicioRepositorio();
        }

        public int GuardarServicio(ServicioDto servicio)
        {
            return _servicioRepositorio.GuardarServicio(servicio);
        }

        public ServicioDto ObtenerServicio(int pk)
        {
            return _servicioRepositorio.ObtenerServicio(pk);
        }

        public List<ServicioDto> ObtenerServicios(int? page, int? size)
        {
            int p = page ?? 0;
            int s = size ?? 10;

            return _servicioRepositorio.ObtenerServicios(p, s);
        }

        public List<ServicioDto> ObtenerServiciosTodos()
        {
            return _servicioRepositorio.ObtenerServiciosTodos();
        }
    }
}
