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
    
    public partial class InventarioVehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventarioVehiculo()
        {
            this.DetalleVentaVehiculo = new HashSet<DetalleVentaVehiculo>();
        }
    
        public int InventarioVehiculoID { get; set; }
        public Nullable<int> CantidadDisponible { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<int> VehiculoID { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> Año { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVentaVehiculo> DetalleVentaVehiculo { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
