using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udi.ecommerceCar.Data.Domain.Entities
{
    internal class TestDriveDto
    {
        private int TestDriveID { get; set; }
        private DateTime FechaProgramada { get; set; }
        private DateTime HoraInicio { get; set; }

        private DateTime HoraFinal { get; set; }

        private int VehiculoID { get; set; }

        private int UsuarioID { get; set; }

    }
}
