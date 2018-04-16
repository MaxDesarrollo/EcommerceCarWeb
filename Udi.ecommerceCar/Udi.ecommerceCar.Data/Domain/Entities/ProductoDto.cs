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
        public int? TipoProductoID { get; set; }
        public string TipoProducto { get; set; }
    }
}
