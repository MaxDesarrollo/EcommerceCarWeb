// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServicioController.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Udi.ecommerceCar.Controllers
{
    using System;
    using System.Web.Mvc;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Domain.Services;

    /// <summary>
    /// The servicio controller.
    /// </summary>
    public class ServicioController : Controller
    {
        /// <summary>
        /// The servicio servicio.
        /// </summary>
        private readonly ServicioServicio servicioServicio = new ServicioServicio();

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
            ServicioDto servicio = this.servicioServicio.ObtenerServicio(id);

            if (servicio != null)
            {
                // Si existe, que mande el view, sino que mande una pagin de error o algo asi
                return this.View(servicio);
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

        // public JsonResult GuardarServicio(string , string descripcion, int cantidad, int tipoProductoId)
        // {
        // try
        // {
        // //Producto prod = ComunServicio.ObtenerDtoFromString<Producto>(producto);
        // int id = productoServicio.ObtenerProductos().Count;
        // ProductoDto prod = new ProductoDto()
        // {
        // ProductoID = id + 1,
        // Nombre = nombre,
        // Descripcion = descripcion,
        // Cantidad = cantidad,
        // TipoProductoID = tipoProductoId
        // };
        // int pk = productoServicio.GuardarProducto(prod);

        // return new JsonResult { Data = new { Success = true, Data = pk } };
        // }
        // catch (Exception ex)
        // {
        // return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
        // }
        // }

        /// <summary>
        /// The obtener servicio.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerServicio(int pk)
        {
            try
            {
                var data = this.servicioServicio.ObtenerServicio(pk);

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

        /// <summary>
        /// The obtener servicios.
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
        public JsonResult ObtenerServicios(int page, int size)
        {
            try
            {
                var data = this.servicioServicio.ObtenerServicios(page, size);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The obtener servicios todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerServiciosTodos()
        {
            try
            {
                var data = this.servicioServicio.ObtenerServiciosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The marcar principal servicio.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult MarcarPrincipalServicio(int id)
        {
            try
            {
                var data = this.servicioServicio.MarcarPrincipalServicio(id);

                string mensaje = data
                                     ? "Servicio marcado como principal correctamente"
                                     : "Servicio desmarcado como principal correctamente";

                return new JsonResult { Data = new { Success = true, Mensaje = mensaje } };
            }
            catch (Exception)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = "Error al querer marcar/desmarcar el servicio" } };
            }
        }

        /// <summary>
        /// The obtener servicios principales.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerServiciosPrincipales()
        {
            try
            {
                var data = this.servicioServicio.ObtenerServiciosPrincipales();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}