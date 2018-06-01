using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    public class ServicioDto
    {
        public int ServicioID { get; set; }

   
        public decimal? Precio { get; set; }
        public bool? Estado { get; set; }

        public string UrlAmigable { get; set; }
        public bool? VisibleMain { get; set; }
        public int? Puntuacion { get; set; }

        public string Descripcion { get; set; }
        public string DescripcionCorta { get; set; }

        public string Nombre { get; set; }


        public Nullable<int> ImagenID { get; set; }
        public int TipoServicioID { get; set; }
        public string TipoServicio { get; set; }
    }
}
