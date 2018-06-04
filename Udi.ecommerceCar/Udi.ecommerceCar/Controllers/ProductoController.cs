// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductoController.cs" company="MC Autoventas">
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
    /// The producto controller.
    /// </summary>
    public class ProductoController : Controller
    {
        /// <summary>
        /// The producto servicio.
        /// </summary>
        private readonly ProductoServicio productoServicio = new ProductoServicio();

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
            ProductoDto producto = this.productoServicio.ObtenerProducto(id);
            return producto != null ? this.View(producto) : this.View();
        }

        /// <summary>
        /// The guardar producto.
        /// </summary>
        /// <param name="productoString">
        /// The producto String.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult GuardarProducto(string productoString)
        {
            try
            {
                ProductoDto productoDto = ComunServicio.ObtenerDtoFromString<ProductoDto>(productoString);
                int id = this.productoServicio.ObtenerProductosTodos().Count;
                ProductoDto prod = new ProductoDto()
                                       {
                                           ProductoId = id + 1, 
                                           Nombre = productoDto.Nombre, 
                                           Descripcion = productoDto.Descripcion, 
                                           DescripcionCorta = productoDto.DescripcionCorta, 
                                           Precio = productoDto.Precio, 
                                           Cantidad = productoDto.Cantidad, 
                                           VisibleMain = productoDto.VisibleMain, 
                                           TipoProductoId = productoDto.TipoProductoId
                                       };
                int pk = this.productoServicio.GuardarProducto(prod);

                return new JsonResult { Data = new { Success = true, Data = pk } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
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

        /// <summary>
        /// The obtener producto.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProducto(int pk)
        {
            try
            {
                var data = this.productoServicio.ObtenerProducto(pk);

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
        /// The obtener productos.
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
        public JsonResult ObtenerProductos(int page, int size)
        {
            try
            {
                var data = this.productoServicio.ObtenerProductos(page, size);

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }

        /// <summary>
        /// The obtener productos todos.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult ObtenerProductosTodos()
        {
            try
            {
                var data = this.productoServicio.ObtenerProductosTodos();

                return new JsonResult { Data = new { Success = true, Data = data } };
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = new { Success = false, Mensaje = ex.Message } };
            }
        }
    }
}