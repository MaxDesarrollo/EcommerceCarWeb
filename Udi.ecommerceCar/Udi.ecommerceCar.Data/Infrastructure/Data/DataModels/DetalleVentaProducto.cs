//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Udi.ecommerceCar.Data.Infrastructure.Data.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetalleVentaProducto
    {
        public int DetalleVentaProducto1 { get; set; }
        public string Cantidad { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
        public Nullable<int> VentaProductoID { get; set; }
        public Nullable<int> ProductoID { get; set; }
        public Nullable<int> VentaID { get; set; }
    
        public virtual Producto Producto { get; set; }
        public virtual VentaProducto VentaProducto { get; set; }
    }
}
