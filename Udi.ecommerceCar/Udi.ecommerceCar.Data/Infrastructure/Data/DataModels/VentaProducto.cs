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
    
    public partial class VentaProducto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VentaProducto()
        {
            this.DetalleVentaProducto = new HashSet<DetalleVentaProducto>();
        }
    
        public int VentaID { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<System.TimeSpan> Hora { get; set; }
        public int UsuarioID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentaProducto> DetalleVentaProducto { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
