using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Login
    {
        public string ValidarUsuario(string cedula, string contrasenia) { 
            ConexionBD con=new ConexionBD();
            return con.ValidarUsuario(cedula,contrasenia);
        }
        public Usuarios TraerUsuario(string cedula)
        {
            ConexionBD con= new ConexionBD();
            return con.TraerUsuario(cedula);
        }

    }
}
