using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estudiante
    {
        public string CedulaEstudiante { get; set; } // primary key
        public string NombreEstudiante { get; set; } // not null
        public string ApellidosEstudiante { get; set; } // not null
        public string Nacionalidad { get; set; } // not null
        public string Correo { get; set; } // not null
        public long NumeroTelefono { get; set; }
        public DateTime? FechaNacimiento { get; set; } // null
        public DateTime FechaRegistro { get; set; } = DateTime.Now; // default getdate()
        public int CarreraId { get; set; } // foreign key
    }
}
