﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udi.ecommerceCar.Data.Domain.Services;
using Udi.ecommerceCar.Data.Infrastructure.Data.DataModels;

namespace Udi.ecommerceCar.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoServicio productoServicio = new ProductoServicio();
        
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GuardarProducto(string nombre, string descripcion, int cantidad, int tipoProductoId)
        {
            try
            {
                //Producto prod = ComunServicio.ObtenerDtoFromString<Producto>(producto);
                Producto prod = new Producto()
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Cantidad = cantidad,
                    TipoProductoID = tipoProductoId
                };

                int pk = productoServicio.GuardarProducto(prod);

                return new JsonResult { Data = new { Success = true, Data = pk } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}