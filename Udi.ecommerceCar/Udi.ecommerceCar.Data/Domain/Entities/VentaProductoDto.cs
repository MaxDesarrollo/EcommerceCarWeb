using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    public class VentaProductoDto
    {
        public int VentaId { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public TimeSpan? Hora { get; set; }
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public int? Estado { get; set; }
        public string EstadoString { get; set; }
        public string EstadoSelect { get; set; }
    }
}
