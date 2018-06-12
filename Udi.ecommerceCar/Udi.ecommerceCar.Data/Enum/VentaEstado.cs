// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VentaEstado.cs" company="MC Autoventas">
//   © 2018 MC Autoventas
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Enum
{
    /// <summary>
    /// The venta estado.
    /// </summary>
    public enum VentaEstado
    {
        /// <summary>
        /// Pendiente, que todavía no realizó el depósito del pago a la empresa
        /// </summary>
        Pendiente = 0, 

        /// <summary>
        /// Pagado, que ya se confirmó su pago del cliente
        /// </summary>
        Pagado = 1, 

        /// <summary>
        /// Enviado, que al cliente se confirmó que le llegó su pedido
        /// </summary>
        Enviado = 2, 

        /// <summary>
        /// Completado, que ya se confirmó el flujo completo del pedido
        /// </summary>
        Completado = 3, 

        /// <summary>
        /// Cancelado por administrador
        /// </summary>
        CanceladoPorAdministrador = 4, 

        /// <summary>
        /// Cancelado por cliente
        /// </summary>
        CanceladoPorCliente = 5
    }
}