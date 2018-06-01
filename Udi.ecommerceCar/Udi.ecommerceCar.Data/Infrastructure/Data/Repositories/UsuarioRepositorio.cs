// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsuarioRepositorio.cs" company="">
//   
// </copyright>
// <summary>
//   The usuario repositorio.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The usuario repositorio.
    /// </summary>
    internal class UsuarioRepositorio : EFRepositorio<Usuario>
    {
        /// <summary>
        /// The iniciar sesion.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="UsuarioDto"/>.
        /// </returns>
        public UsuarioDto IniciarSesion(string username, string password)
        {
            try
            {
                //// Usuario usuario = Get(pk);
                //// return usuario;
                return
                    this.BuildQuery()
                        .Select(
                            usuario =>
                            new UsuarioDto()
                                {
                                    UsuarioId = usuario.UsuarioID, 
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

        /// <summary>
        /// The obtener usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="Usuario"/>.
        /// </returns>
        public Usuario ObtenerUsuario(int pk)
        {
            try
            {
                Usuario usuario = this.Get(pk);

                return usuario;

                ////return BuildQuery().Where(x => x == pk).Select(inventarioVehiculo => new Usuario()
                ////{
                ////    VehiculoID = inventarioVehiculo.Vehiculo.VehiculoID,
                ////    CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                ////    Precio = inventarioVehiculo.Precio,
                ////    Año = (DateTime)inventarioVehiculo.Año,
                ////    //ModeloID = (int)vehiculo.ModeloID,
                ////    CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas,
                ////    HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive,
                ////    Estado = inventarioVehiculo.Vehiculo.Estado,
                ////    NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo,
                ////    MarcaID = inventarioVehiculo.Vehiculo.MarcaID,
                ////    NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre,
                ////    PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen,
                ////    TipoVehiculoID = inventarioVehiculo.Vehiculo.TipoVehiculoID,
                ////    NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre,
                ////    TipoCajaID = inventarioVehiculo.Vehiculo.TipoCajaID,
                ////    NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
                ////}).First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}