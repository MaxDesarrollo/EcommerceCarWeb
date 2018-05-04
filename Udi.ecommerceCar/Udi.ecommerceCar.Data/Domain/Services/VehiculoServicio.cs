using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class VehiculoServicio
    {
        private readonly VehiculoRepositorio vehiculoRepositorio;

        public VehiculoServicio()
        {
            this.vehiculoRepositorio = new VehiculoRepositorio();
        }

        public int GuardarVehiculo(VehiculoDto vehiculo)
        {
            return vehiculoRepositorio.GuardarVehiculo(vehiculo);
        }

        //public VehiculoDto ObtenerVehiculo(int pk)
        //{
        //    return vehiculoRepositorio.ObtenerVehiculo(pk);
        //}

        public List<VehiculoDto> ObtenerVehiculos(int? page, int? size)
        {
            int p = page == null ? 10 : (int)page;
            int s = size == null ? 10 : (int)size;

            return vehiculoRepositorio.ObtenerVehiculos(p, s);
        }

        public List<VehiculoDto> ObtenerVehiculosTodos()
        {
            return vehiculoRepositorio.ObtenerVehiculosTodos();
        }
    }
}
