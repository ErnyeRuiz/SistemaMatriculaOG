using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CambioContraseña
    {
        public void CambioContrasenia(string cedula,string contrasenia,bool EstadoIngreso) { 
            ConexionBD con=new ConexionBD();
            con.CambioContrasenia(cedula,contrasenia,EstadoIngreso);
        }

    }
}
