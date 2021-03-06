﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VentaProductoServicio.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Udi.ecommerceCar.Data.Domain.Services
{
    using System.Collections.Generic;

    using Udi.ecommerceCar.Data.Domain.Entities;
    using Udi.ecommerceCar.Data.Enum;
    using Udi.ecommerceCar.Data.Infrastructure.Data.Repositories;

    /// <summary>
    /// The venta producto servicio.
    /// </summary>
    public class VentaProductoServicio
    {
        /// <summary>
        /// The venta producto repositorio.
        /// </summary>
        private readonly VentaProductoRepositorio ventaProductoRepositorio;

        /// <summary>
        /// Initializes a new instance of the <see cref="VentaProductoServicio"/> class.
        /// </summary>
        public VentaProductoServicio()
        {
            this.ventaProductoRepositorio = new VentaProductoRepositorio();
        }

        /// <summary>
        /// The cambiar estado venta producto.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <param name="nuevoEstado">
        /// The nuevo estado.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CambiarEstadoVentaProducto(int ventaProductoId, int nuevoEstado)
        {
            VentaProductoDto ventaProductoDto = this.ventaProductoRepositorio.CambiarEstadoVentaProducto(ventaProductoId, nuevoEstado);
            return Utilidades.ObtenerSelectVentaProductoEstado(ventaProductoDto);
        }

        /// <summary>
        /// The cancelar pedido por cliente.
        /// </summary>
        /// <param name="ventaProductoId">
        /// The venta producto id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CancelarPedidoPorCliente(int ventaProductoId)
        {
            VentaProductoDto ventaProductoDto = this.ventaProductoRepositorio.CambiarEstadoVentaProducto(ventaProductoId, (int)VentaEstado.CanceladoPorCliente);
            return ventaProductoDto != null;
        }

        /// <summary>
        /// The obtener venta producto.
        /// </summary>
        /// <param name="ventaProductoDto">
        /// The venta producto dto.
        /// </param>
        /// <returns>
        /// The <see cref="VentaProductoDto"/>.
        /// </returns>
        public VentaProductoDto ObtenerVentaProducto(VentaProductoDto ventaProductoDto)
        {
            return this.ventaProductoRepositorio.ObtenerVentaProducto(ventaProductoDto);
        }

        /// <summary>
        /// The obtener ventas productos todos.
        /// </summary>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VentaProductoDto> ObtenerVentasProductosTodos()
        {
            var listaVentaProductoDto = this.ventaProductoRepositorio.ObtenerVentasProductosTodos();

            foreach (var ventaProducto in listaVentaProductoDto)
            {
                ventaProducto.EstadoSelect = Utilidades.ObtenerSelectVentaProductoEstado(ventaProducto);
            }

            return listaVentaProductoDto;
        }

        /// <summary>
        /// The obtener ventas productos usuario.
        /// </summary>
        /// <param name="pk">
        /// The pk.
        /// </param>
        /// <returns>
        /// The <see>
        ///         <cref>List</cref>
        ///     </see>
        ///     .
        /// </returns>
        public List<VentaProductoDto> ObtenerVentasProductosUsuario(int pk)
        {
            return this.ventaProductoRepositorio.ObtenerVentasProductosUsuario(pk);
        }
    }
}