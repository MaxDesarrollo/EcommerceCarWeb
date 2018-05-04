using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class VehiculoRepositorio : EFRepositorio<Vehiculo>
    {
        public int GuardarVehiculo(VehiculoDto vehiculo)
        {
            Vehiculo newVehiculo = new Vehiculo()
            {
                ////////////////////////////CAMBIAR EN LA BD
                InventarioVehiculoID = vehiculo.VehiculoID,                     // CAMBIAR el nombre de la id
                CantidadDispnible = vehiculo.CantidadDisponible.ToString(),     // CAMBIAR Dispnible
                Precio = vehiculo.Precio,                                       // CAMBIAR de string a decimal
                Año = vehiculo.Año.ToString(),                                  // CAMBIAR de string a datetime
                ModeloID = vehiculo.ModeloID
            };

            Add(newVehiculo);
            SaveChanges();

            return newVehiculo.InventarioVehiculoID;
        }

        //public VehiculoDto ObtenerVehiculo(int pk)
        //{
        //    Vehiculo vehiculo = Get(pk);

        //    return new VehiculoDto()
        //    {
        //        ////////////////////////////CAMBIAR EN LA BD
        //        VehiculoID = vehiculo.InventarioVehiculoID,                     // CAMBIAR el nombre de la id
        //        CantidadDisponible = int.Parse(vehiculo.CantidadDispnible),     // CAMBIAR Dispnible
        //        Precio = decimal.Parse(vehiculo.Precio.ToString()),             // CAMBIAR de string a decimal
        //        Año = DateTime.Parse(vehiculo.Año.ToString()),                  // CAMBIAR de string a datetime
        //        ModeloID = (int)vehiculo.ModeloID,
        //        CantidadPuertas = (int)vehiculo.Modelo.CantidadPuertas,
        //        HabilitadoTestDrive = (bool)vehiculo.Modelo.HabilitadoTestDrive,
        //        Estado = bool.Parse(vehiculo.Modelo.Estado.Value.ToString()),   // CAMBIAR Estado, muy dificil de castear
        //        NombreModelo = vehiculo.Modelo.NombreModelo,
        //        MarcaID = vehiculo.Modelo.MarcaID,
        //        NombreMarca = vehiculo.Modelo.Marca.Nombre,
        //        PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
        //        TipoVehiculoID = (int)vehiculo.Modelo.TipoVehiculoID,
        //        NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
        //        TipoCajaID = (int)vehiculo.Modelo.TipoCajaID,
        //        NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
        //        // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
        //        // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
        //    };
        //}

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
        public List<VehiculoDto> ObtenerVehiculos(int page, int size)
        {
            return this.BuildQuery().Select(vehiculo => new VehiculoDto()
            {
                ////////////////////////////CAMBIAR EN LA BD
                VehiculoID = vehiculo.InventarioVehiculoID,                     // CAMBIAR el nombre de la id
                CantidadDisponible = vehiculo.CantidadDispnible,                // CAMBIAR Dispnible
                Precio = vehiculo.Precio,                                       // Ver si dejarlo en Nullable
                Año = vehiculo.Año,                                             // CAMBIAR de string a datetime
                ModeloID = vehiculo.ModeloID,                                   // Ver si dejarlo en Nullable
                CantidadPuertas = vehiculo.Modelo.CantidadPuertas,              // Ver si dejarlo en Nullable
                HabilitadoTestDrive = vehiculo.Modelo.HabilitadoTestDrive,      // Ver si dejarlo en Nullable
                Estado = vehiculo.Modelo.Estado,                                // CAMBIAR Estado a bool
                NombreModelo = vehiculo.Modelo.NombreModelo,
                MarcaID = vehiculo.Modelo.MarcaID,
                NombreMarca = vehiculo.Modelo.Marca.Nombre,
                PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
                TipoVehiculoID = vehiculo.Modelo.TipoVehiculoID,                // Ver si dejarlo en Nullable
                NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
                TipoCajaID = vehiculo.Modelo.TipoCajaID,                        // Ver si dejarlo en Nullable
                NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
                // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
                // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
            })
            .OrderBy(x => x.VehiculoID)
            .Skip(page * size)
            .Take(size)
            .ToList();


            //////////////////////////////////CAMBIAR EN LA BD
            //////VehiculoID = vehiculo.InventarioVehiculoID,                     // CAMBIAR el nombre de la id
            //////    CantidadDisponible = int.Parse(vehiculo.CantidadDispnible),     // CAMBIAR Dispnible
            //////    Precio = decimal.Parse(vehiculo.Precio.ToString()),             // CAMBIAR de string a decimal
            //////    Año = DateTime.Parse(vehiculo.Año.ToString()),                  // CAMBIAR de string a datetime
            //////    ModeloID = (int)vehiculo.ModeloID,
            //////    CantidadPuertas = (int)vehiculo.Modelo.CantidadPuertas,
            //////    HabilitadoTestDrive = (bool)vehiculo.Modelo.HabilitadoTestDrive,
            //////    Estado = bool.Parse(vehiculo.Modelo.Estado.Value.ToString()),   // CAMBIAR Estado, muy dificil de castear
            //////    NombreModelo = vehiculo.Modelo.NombreModelo,
            //////    MarcaID = vehiculo.Modelo.MarcaID,
            //////    NombreMarca = vehiculo.Modelo.Marca.Nombre,
            //////    PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
            //////    TipoVehiculoID = (int)vehiculo.Modelo.TipoVehiculoID,
            //////    NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
            //////    TipoCajaID = (int)vehiculo.Modelo.TipoCajaID,
            //////    NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
            //////    // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
            //////    // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
        }

        public List<VehiculoDto> ObtenerVehiculosTodos()
        {
            return this.BuildQuery().Select(vehiculo => new VehiculoDto()
            {
                ////////////////////////////CAMBIAR EN LA BD
                VehiculoID = vehiculo.InventarioVehiculoID,                     // CAMBIAR el nombre de la id
                CantidadDisponible = vehiculo.CantidadDispnible,                // CAMBIAR Dispnible
                Precio = vehiculo.Precio,             
                Año = vehiculo.Año,                                             // CAMBIAR de string a datetime
                ModeloID = (int)vehiculo.ModeloID,
                CantidadPuertas = (int)vehiculo.Modelo.CantidadPuertas,
                HabilitadoTestDrive = (bool)vehiculo.Modelo.HabilitadoTestDrive,
                Estado = vehiculo.Modelo.Estado,   // CAMBIAR Estado, muy dificil de castear
                NombreModelo = vehiculo.Modelo.NombreModelo,
                MarcaID = vehiculo.Modelo.MarcaID,
                NombreMarca = vehiculo.Modelo.Marca.Nombre,
                PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
                TipoVehiculoID = (int)vehiculo.Modelo.TipoVehiculoID,
                NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
                TipoCajaID = (int)vehiculo.Modelo.TipoCajaID,
                NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
                // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
                // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
            })
            .ToList();
        }
    }
}
