using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    class UsuarioRepositorio : EFRepositorio<Usuario>
    {


        public Usuario ObtenerUsuario(int pk)
        {
            try
            {
                Usuario usuario = Get(pk);

                return usuario;

                //return BuildQuery().Where(x => x == pk).Select(inventarioVehiculo => new Usuario()
                //{
                //    VehiculoID = inventarioVehiculo.Vehiculo.VehiculoID,
                //    CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                //    Precio = inventarioVehiculo.Precio,
                //    Año = (DateTime)inventarioVehiculo.Año,
                //    //ModeloID = (int)vehiculo.ModeloID,
                //    CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas,
                //    HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive,
                //    Estado = inventarioVehiculo.Vehiculo.Estado,
                //    NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo,
                //    MarcaID = inventarioVehiculo.Vehiculo.MarcaID,
                //    NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre,
                //    PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen,
                //    TipoVehiculoID = inventarioVehiculo.Vehiculo.TipoVehiculoID,
                //    NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre,
                //    TipoCajaID = inventarioVehiculo.Vehiculo.TipoCajaID,
                //    NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
                //}).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UsuarioDto IniciarSesion(string username, string password)
        {
            try
            {
                //Usuario usuario = Get(pk);
                //return usuario;
                
                return BuildQuery()
                .Select(usuario => new UsuarioDto()
                {
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Username = usuario.Username,
                    Password = usuario.Password
                })
                .First(x => x.Username == username && x.Password == password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
