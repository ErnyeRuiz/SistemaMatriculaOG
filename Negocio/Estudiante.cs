using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Estudiante
    {
        public static Entidades.Estudiante BuscarEstudiante(String cedula)
        {
            
            try
            {
                Datos.ConexionBD conexionBD = new Datos.ConexionBD();

                return conexionBD.TraerEstudiante(cedula);

            }catch(Exception)
            {
                return null;
            }
        }
    }
}
