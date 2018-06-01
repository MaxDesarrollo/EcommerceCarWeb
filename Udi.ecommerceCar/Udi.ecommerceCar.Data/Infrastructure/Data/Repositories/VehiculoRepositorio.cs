using System;
using System.Collections.Generic;
using System.Linq;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class VehiculoRepositorio : EFRepositorio<InventarioVehiculo>
    {
        //public int GuardarVehiculo(VehiculoDto vehiculo)
        //{
        //    Vehiculo newVehiculo = new Vehiculo()
        //    {
        //        ////////////////////////////CAMBIAR EN LA BD
        //        VehiculoID = vehiculo.VehiculoID,
        //        //CantidadDispnible = vehiculo.CantidadDisponible.ToString(),     // CAMBIAR Dispnible
        //        Precio = vehiculo.Precio,                                       // CAMBIAR de string a decimal
        //        Año = vehiculo.Año.ToString(),                                  // CAMBIAR de string a datetime
        //        ModeloID = vehiculo.ModeloID
        //    };

        //    Add(newVehiculo);
        //    SaveChanges();

        //    return newVehiculo.InventarioVehiculoID;
        //}

        public VehiculoDto ObtenerVehiculo(int pk)
        {
            try
            {
                //Vehiculo vehiculo = Get(pk);

                return BuildQuery().Where(x => x.VehiculoID == pk).Select(inventarioVehiculo => new VehiculoDto()
                {
                    VehiculoID = inventarioVehiculo.Vehiculo.VehiculoID,
                    CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                    Precio = inventarioVehiculo.Precio,
                    Año = (DateTime)inventarioVehiculo.Año,
                    //ModeloID = (int)vehiculo.ModeloID,
                    CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas,
                    HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive,
                    Estado = inventarioVehiculo.Vehiculo.Estado,
                    NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo,
                    MarcaID = inventarioVehiculo.Vehiculo.MarcaID,
                    NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre,
                    PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen,
                    TipoVehiculoID = inventarioVehiculo.Vehiculo.TipoVehiculoID,
                    NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre,
                    TipoCajaID = inventarioVehiculo.Vehiculo.TipoCajaID,
                    NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
                }).First();
            }
            catch (Exception)
            {
                return null;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco
        public List<VehiculoDto> ObtenerVehiculos(int page, int size)
        {
            return BuildQuery().Select(inventarioVehiculo => new VehiculoDto()
            {
                VehiculoID = inventarioVehiculo.Vehiculo.VehiculoID,
                CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                Precio = inventarioVehiculo.Precio,
                Año = (DateTime)inventarioVehiculo.Año,
                //ModeloID = (int)vehiculo.ModeloID,
                CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas,
                HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive,
                Estado = inventarioVehiculo.Vehiculo.Estado,
                NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo,
                MarcaID = inventarioVehiculo.Vehiculo.MarcaID,
                NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre,
                PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen,
                TipoVehiculoID = inventarioVehiculo.Vehiculo.TipoVehiculoID,
                NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre,
                TipoCajaID = inventarioVehiculo.Vehiculo.TipoCajaID,
                NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
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
            return BuildQuery().Select(inventarioVehiculo => new VehiculoDto()
            {
                VehiculoID = inventarioVehiculo.Vehiculo.VehiculoID,
                CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                Precio = inventarioVehiculo.Precio,
                Año = (DateTime)inventarioVehiculo.Año,
                //ModeloID = (int)vehiculo.ModeloID,
                CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas,
                HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive,
                Estado = inventarioVehiculo.Vehiculo.Estado,
                NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo,
                MarcaID = inventarioVehiculo.Vehiculo.MarcaID,
                NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre,
                PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen,
                ImagenID = inventarioVehiculo.Vehiculo.ImagenID,
                Descripcion = inventarioVehiculo.Vehiculo.Descripcion,
                DescripcionCorta = inventarioVehiculo.Vehiculo.DescripcionCorta,
                TipoVehiculoID = inventarioVehiculo.Vehiculo.TipoVehiculoID,
                NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre,
                TipoCajaID = inventarioVehiculo.Vehiculo.TipoCajaID,
                NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre

            })
            .ToList();
        }
    }
}
