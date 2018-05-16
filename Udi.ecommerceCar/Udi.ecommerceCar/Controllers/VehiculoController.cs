using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udi.ecommerceCar.Data.Domain.Entities;
using Udi.ecommerceCar.Data.Domain.Services;

namespace Udi.ecommerceCar.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly VehiculoServicio vehiculoServicio = new VehiculoServicio();

        // GET: Vehiculo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detalle(int id)
        {
            VehiculoDto vehiculo = vehiculoServicio.ObtenerVehiculo(id);

            if (vehiculo != null)
            {
                //Si existe, que mande el view, sino que mande una pagin de error o algo asi
                return View(vehiculo);
            }

            return View();
        }

        //public JsonResult GuardarProducto(int cantidadDisponible, decimal precio, DateTime anho, int modeloId, int cantidadPuertas, )
        //{
        //    try
        //    {
        //        //Producto prod = ComunServicio.ObtenerDtoFromString<Producto>(producto);
        //        int id = vehiculoServicio.ObtenerVehiculosTodos().Count;                        // CAMBIAR A UN COUNT MAS LOGICO
        //        VehiculoDto veh = new VehiculoDto()
        //        {
        //            CantidadDisponible = cantidadDisponible,
        //            Precio = precio,
        //            Año = anho,
        //            ModeloID = modeloId,
        //            CantidadPuertas = (int)vehiculo.Modelo.CantidadPuertas,
        //            HabilitadoTestDrive = (bool)vehiculo.Modelo.HabilitadoTestDrive,
        //            Estado = bool.Parse(vehiculo.Modelo.Estado.Value.ToString()),   // CAMBIAR Estado, muy dificil de castear
        //            NombreModelo = vehiculo.Modelo.NombreModelo,
        //            MarcaID = vehiculo.Modelo.MarcaID,
        //            NombreMarca = vehiculo.Modelo.Marca.Nombre,
        //            PaisOrigen = vehiculo.Modelo.Marca.PaisOrigen,
        //            TipoVehiculoID = (int)vehiculo.Modelo.TipoVehiculoID,
        //            NombreTipoVehiculo = vehiculo.Modelo.TipoVehiculo.Nombre,
        //            TipoCajaID = (int)vehiculo.Modelo.TipoCajaID,
        //            NombreTipoCaja = vehiculo.Modelo.TipoCaja.Nombre
        //            // VER MODELO Y VEHICULO, PARECEN ESTAR AL REVES
        //            // VER LOS NULOS, SI CAMBIAR EN EL DTO O CASTEARLOS COMO ESTAN AHORITA
        //        };
        //        int pk = vehiculoServicio.GuardarVehiculo(veh);

        //        return new JsonResult { Data = new { Success = true, Data = pk } };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
        //    }
        //}

        public JsonResult ObtenerVehiculo(int pk)
        {
            try
            {
                var data = vehiculoServicio.ObtenerVehiculo(pk);

                if (data == null)
                {
                    return new JsonResult { Data = new { Success = false } };
                }

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult ObtenerVehiculosTodos()
        {
            try
            {
                var data = vehiculoServicio.ObtenerVehiculosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        public JsonResult ObtenerVehiculos(int page, int size)
        {
            try
            {
                var data = vehiculoServicio.ObtenerVehiculos(page, size);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }


    }
}