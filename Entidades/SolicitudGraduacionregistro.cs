using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SolicitudGraduacionregistro
    {
        // Identificador único para la solicitud de graduación
        public int Id { get; set; }

        // Cédula del estudiante que realiza la solicitud
        public string CedulaEstudiante { get; set; }

        // Opción de graduación seleccionada
        public string OpcionGraduacion { get; set; }

        // Estado de la solicitud (ejemplo: pendiente, aprobada, rechazada)
        public string Estado { get; set; }

        // Fecha en que se creó la solicitud de graduación
        public DateTime FechaSolicitud { get; set; }



        // Constructor por defecto
        public SolicitudGraduacionregistro()
        {
            // Inicializa propiedades predeterminadas
            Estado = "pendiente";
            FechaSolicitud = DateTime.Now;
        }

        // Método ToString para representación legible de la clase
        public override string ToString()
        {
            return $"SolicitudGraduacionregistro [Id={Id}, CedulaEstudiante={CedulaEstudiante}, " +
                   $"OpcionGraduacion={OpcionGraduacion}, Estado={Estado}, FechaSolicitud={FechaSolicitud}, ";
        }

        // Agrega otros métodos según sea necesario aquí
    }
}
