using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    public class ProductoDto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Cantidad { get; set; }

        public string DescripcionCorta { get; set; }
        public string UrlAmigable { get; set; }
        public Nullable<Boolean> VisibleMain { get; set; }
        public Nullable<int> Puntuacion { get; set; }

        public Nullable<int> ImagenId { get; set; }
        public Nullable<decimal> Precio { get; set; }

        public int? TipoProductoID { get; set; }
        public string TipoProducto { get; set; }
    }
}
