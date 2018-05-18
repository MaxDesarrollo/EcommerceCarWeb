using System.Collections.Generic;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

namespace Udi.ecommerceCar.Data.Domain.Services
{
    public class VehiculoServicio
    {
        private readonly VehiculoRepositorio _vehiculoRepositorio;

        public VehiculoServicio()
        {
            _vehiculoRepositorio = new VehiculoRepositorio();
        }

        //public int GuardarVehiculo(VehiculoDto vehiculo)
        //{
        //    return _vehiculoRepositorio.GuardarVehiculo(vehiculo);
        //}

        public VehiculoDto ObtenerVehiculo(int pk)
        {
            return _vehiculoRepositorio.ObtenerVehiculo(pk);
        }

        public List<VehiculoDto> ObtenerVehiculos(int? page, int? size)
        {
            var p = page ?? 0;
            var s = size ?? 10;

            return _vehiculoRepositorio.ObtenerVehiculos(p, s);
        }

        public List<VehiculoDto> ObtenerVehiculosTodos()
        {
            return _vehiculoRepositorio.ObtenerVehiculosTodos();
        }
    }
}
