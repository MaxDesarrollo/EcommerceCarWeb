using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class ServicioServicio
    {
        private readonly ServicioRepositorio servicioRepositorio;

        public ServicioServicio()
        {
            this.servicioRepositorio = new ServicioRepositorio();
        }

        public int GuardarServicio(ServicioDto servicio)
        {
            return servicioRepositorio.GuardarServicio(servicio);
        }

        public ServicioDto ObtenerServicio(int pk)
        {
            return servicioRepositorio.ObtenerServicio(pk);
        }

        public List<ServicioDto> ObtenerServicios(int? page, int? size)
        {
            int p = page == null ? 10 : (int)page;
            int s = size == null ? 10 : (int)size;

            return servicioRepositorio.ObtenerServicios(p, s);
        }

        public List<ServicioDto> ObtenerServiciosTodos()
        {
            return servicioRepositorio.ObtenerServiciosTodos();
        }
    }
}
