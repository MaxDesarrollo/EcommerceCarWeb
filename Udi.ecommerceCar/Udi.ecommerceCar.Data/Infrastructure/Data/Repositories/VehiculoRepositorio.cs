// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoRepositorio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Udi.ecommerceCar.Data.Infrastructure.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

    /// <summary>
    /// The vehiculo repositorio.
    /// </summary>
    internal class VehiculoRepositorio : EFRepositorio<InventarioVehiculo>
    {
        /// <summary>
        /// The marcar principal vehiculo.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool MarcarPrincipalVehiculo(int id)
        {
            var vehiculo = this.Get(id);
            vehiculo.VisibleMain = !vehiculo.VisibleMain;
            this.SaveChanges();

            return (bool)vehiculo.VisibleMain;
        }

        // public int GuardarVehiculo(VehiculoDto vehiculo)
        // {
        // Vehiculo newVehiculo = new Vehiculo()
        // {
        // ////////////////////////////CAMBIAR EN LA BD
        // VehiculoID = vehiculo.VehiculoID,
        // //CantidadDispnible = vehiculo.CantidadDisponible.ToString(),     // CAMBIAR Dispnible
        // Precio = vehiculo.Precio,                                       // CAMBIAR de string a decimal
        // Año = vehiculo.Año.ToString(),                                  // CAMBIAR de string a datetime
        // ModeloID = vehiculo.ModeloID
        // };

        // Add(newVehiculo);
        // SaveChanges();

        // return newVehiculo.InventarioVehiculoID;
        // }

        /// <summary>
        /// The obtener vehiculo.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="VehiculoDto"/>.
        /// </returns>
        public VehiculoDto ObtenerVehiculo(int pk)
        {
            try
            {
                // Vehiculo vehiculo = Get(pk);
                return
                    this.BuildQuery()
                        .Where(x => x.VehiculoID == pk)
                        .Select(
                            inventarioVehiculo =>
                            new VehiculoDto()
                                {
                                    InventarioVehiculoId = inventarioVehiculo.InventarioVehiculoID, 
                                    VehiculoId = inventarioVehiculo.Vehiculo.VehiculoID, 
                                    CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                                    Color = inventarioVehiculo.Color,
                                    Precio = inventarioVehiculo.Precio, 
                                    Año = (DateTime)inventarioVehiculo.Año, 

                                    // ModeloID = (int)vehiculo.ModeloID,
                                    CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas, 
                                    HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive, 
                                    Estado = inventarioVehiculo.Vehiculo.Estado, 
                                    NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo, 
                                    MarcaId = inventarioVehiculo.Vehiculo.MarcaID, 
                                    NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre, 
                                    PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen, 
                                    TipoVehiculoId = inventarioVehiculo.Vehiculo.TipoVehiculoID, 
                                    NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre, 
                                    TipoCajaId = inventarioVehiculo.Vehiculo.TipoCajaID, 
                                    NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
                                }).First();
            }
            catch (ExcepcionComercio)
            {
                return null;
            }
        }

        ////////////EFRepositorio tiene su propio metodo para llamar por paginas, seria estudiarlo un poco

        /// <summary>
        /// The obtener vehiculos.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VehiculoDto> ObtenerVehiculos(int page, int size)
        {
            return
                this.BuildQuery()
                    .Select(
                        inventarioVehiculo =>
                        new VehiculoDto()
                            {
                                InventarioVehiculoId = inventarioVehiculo.InventarioVehiculoID, 
                                VehiculoId = inventarioVehiculo.Vehiculo.VehiculoID, 
                                CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                                Color = inventarioVehiculo.Color,
                                Precio = inventarioVehiculo.Precio, 
                                Año = (DateTime)inventarioVehiculo.Año, 

                                // ModeloID = (int)vehiculo.ModeloID,
                                CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas, 
                                HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive, 
                                Estado = inventarioVehiculo.Vehiculo.Estado, 
                                NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo, 
                                MarcaId = inventarioVehiculo.Vehiculo.MarcaID, 
                                NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre, 
                                PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen, 
                                TipoVehiculoId = inventarioVehiculo.Vehiculo.TipoVehiculoID, 
                                NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre, 
                                TipoCajaId = inventarioVehiculo.Vehiculo.TipoCajaID, 
                                NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre, 
                                VisibleMain = inventarioVehiculo.VisibleMain
                            })
                    .OrderBy(x => x.VehiculoId)
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

        /// <summary>
        /// The obtener vehiculos principales.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VehiculoDto> ObtenerVehiculosPrincipales()
        {
            return
                this.BuildQuery()
                    .Where(x => x.VisibleMain == true)
                    .Select(
                        inventarioVehiculo =>
                        new VehiculoDto()
                            {
                                VehiculoId = inventarioVehiculo.Vehiculo.VehiculoID, 
                                CantidadDisponible = inventarioVehiculo.CantidadDisponible, 
                                Precio = inventarioVehiculo.Precio, 
                                Año = (DateTime)inventarioVehiculo.Año,
                                Color = inventarioVehiculo.Color,
                                CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas, 
                                HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive, 
                                Estado = inventarioVehiculo.Vehiculo.Estado, 
                                NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo, 
                                MarcaId = inventarioVehiculo.Vehiculo.MarcaID, 
                                NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre, 
                                PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen, 
                                ImagenId = inventarioVehiculo.Vehiculo.ImagenID, 
                                Descripcion = inventarioVehiculo.Vehiculo.Descripcion, 
                                DescripcionCorta = inventarioVehiculo.Vehiculo.DescripcionCorta, 
                                TipoVehiculoId = inventarioVehiculo.Vehiculo.TipoVehiculoID, 
                                NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre, 
                                TipoCajaId = inventarioVehiculo.Vehiculo.TipoCajaID, 
                                NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre
                            }).ToList();
        }

        /// <summary>
        /// The obtener vehiculos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VehiculoDto> ObtenerVehiculosTodos()
        {
            return
                this.BuildQuery()
                    .Select(
                        inventarioVehiculo =>
                        new VehiculoDto()
                            {
                                InventarioVehiculoId = inventarioVehiculo.InventarioVehiculoID, 
                                VehiculoId = inventarioVehiculo.Vehiculo.VehiculoID, 
                                CantidadDisponible = inventarioVehiculo.CantidadDisponible,
                                Color = inventarioVehiculo.Color,
                                Precio = inventarioVehiculo.Precio, 
                                Año = (DateTime)inventarioVehiculo.Año, 
                                CantidadPuertas = inventarioVehiculo.Vehiculo.CantidadPuertas, 
                                HabilitadoTestDrive = inventarioVehiculo.Vehiculo.HabilitadoTestDrive, 
                                Estado = inventarioVehiculo.Vehiculo.Estado, 
                                NombreModelo = inventarioVehiculo.Vehiculo.NombreModelo, 
                                MarcaId = inventarioVehiculo.Vehiculo.MarcaID, 
                                NombreMarca = inventarioVehiculo.Vehiculo.Marca.Nombre, 
                                PaisOrigen = inventarioVehiculo.Vehiculo.Marca.PaisOrigen, 
                                ImagenId = inventarioVehiculo.Vehiculo.ImagenID, 
                                Descripcion = inventarioVehiculo.Vehiculo.Descripcion, 
                                DescripcionCorta = inventarioVehiculo.Vehiculo.DescripcionCorta, 
                                TipoVehiculoId = inventarioVehiculo.Vehiculo.TipoVehiculoID, 
                                NombreTipoVehiculo = inventarioVehiculo.Vehiculo.TipoVehiculo.Nombre, 
                                TipoCajaId = inventarioVehiculo.Vehiculo.TipoCajaID, 
                                NombreTipoCaja = inventarioVehiculo.Vehiculo.TipoCaja.Nombre, 
                                VisibleMain = inventarioVehiculo.VisibleMain
                            }).ToList();
        }
    }
}