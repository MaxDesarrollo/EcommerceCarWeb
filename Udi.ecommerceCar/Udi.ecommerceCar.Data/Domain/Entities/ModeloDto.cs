using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    class ModeloDto
    {
        private int VehiculoID { get; set; }

        private int CantidadPuertas { get; set; }

        private Boolean HabilitadoTestDrive { get; set; }

        private Boolean Estado { get; set;}

        private int TipoVehiculoID { get; set; }
        private int TipoCajaID { get; set; }

        private string NombreModelo { get; set; }

        private int MarcaID { get; set; }


    }
}
