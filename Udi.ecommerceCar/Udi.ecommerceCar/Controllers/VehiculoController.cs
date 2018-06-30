// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VehiculoController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain;
    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The vehiculo controller.
    /// </summary>
    public class VehiculoController : Controller
    {
        /// <summary>
        /// The vehiculo servicio.
        /// </summary>
        private readonly VehiculoServicio vehiculoServicio = new VehiculoServicio();

        /// <summary>
        /// The detalle.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Detalle(int id)
        {
            VehiculoDto vehiculo = this.vehiculoServicio.ObtenerVehiculo(id);

            if (vehiculo != null)
            {
                // Si existe, que mande el view, sino que mande una pagin de error o algo asi
                return this.View(vehiculo);
            }

            return this.View();
        }
        
        /// <summary>
        /// The index.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        // public JsonResult GuardarProducto(int cantidadDisponible, decimal precio, DateTime anho, int modeloId, int cantidadPuertas, )
        // {
        // try
        // {
        // //Producto prod = ComunServicio.ObtenerDtoFromString<Producto>(producto);
        // int id = vehiculoServicio.ObtenerVehiculosTodos().Count;                        // CAMBIAR A UN COUNT MAS LOGICO
        // VehiculoDto veh = new VehiculoDto()
        // {
        // CantidadDisponible = cantidadDisponible,
        // Precio = precio,
        // Año = anho,
        // ModeloID = modeloId,
        // CantidadPuertas = (int)vehiculo.Modelo.CantidadPuertas,
        // HabilitadoTestDrive = (bool)vehiculo.Modelo.HabilitadoTestDrive,
        // Estado = bool.Parse(vehiculo.Modelo.Estado.Value.ToString()),   // CAMBIAR Estado, muy dificil de castear
        // NombreModelo = vehiculo.Modelo.NombreModelo,
        // MarcaID = vehiculo.Modelo.MarcaID,
        // NombreMarca = vehiculo.Modelo.Marca.Nombre,
        // PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
        // TipoVehiculoID = (int)vehiculo.Modelo.TipoVehiculoID,
        // NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
        // TipoCajaID = (int)vehiculo.Modelo.TipoCajaID,
        // NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
        // // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
        // // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
        // };
        // int pk = vehiculoServicio.GuardarVehiculo(veh);

        // return new JsonResult { Data = new { Success = true, Data = pk } };
        // }
        // catch (Exception ex)
        // {
        // return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
        // }
        // }

        /// <summary>
        /// The obtener vehiculo.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVehiculo(int pk)
        {
            try
            {
                var data = this.vehiculoServicio.ObtenerVehiculo(pk);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

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
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVehiculos(int? page, int? size)
        {
            try
            {
                var data = this.vehiculoServicio.ObtenerVehiculos(page, size);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The obtener vehiculos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVehiculosTodos()
        {
            try
            {
                var data = this.vehiculoServicio.ObtenerVehiculosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (ExcepcionComercio ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The marcar principal vehiculo.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>JsonResult</cref>
        ///     </see>
        ///     .
        /// </returns>
        public JsonResult MarcarPrincipalVehiculo(int id)
        {
            try
            {
                var data = this.vehiculoServicio.MarcarPrincipalVehiculo(id);

                string mensaje = data
                                     ? "Vehículo marcado como principal correctamente"
                                     : "Vehículo desmarcado como principal correctamente";

                return new JsonResult { Data = new { Success = true, Mensaje = mensaje } };
            }
            catch (ExcepcionComercio)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = "Error al querer marcar/desmarcar el producto" } };
            }
        }

        /// <summary>
        /// The obtener vehiculos principales.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerVehiculosPrincipales()
        {
            var data = this.vehiculoServicio.ObtenerVehiculosPrincipales();
            return new JsonResult { Data = new { Success = true, Data = data } };
        }
    }
}