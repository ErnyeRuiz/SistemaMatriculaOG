using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class SolicitudesRegistro
    {
        public List<Carreras> TraerCarreras() {
            ConexionBD con=new ConexionBD();
            return con.TraerCarreras();
        }

        public void RegistrarSolicitud(string cedula) { 
            ConexionBD con=new ConexionBD();
            con.RegistroSolicitudDeRegistro(cedula,1);
            
        }

        public void RegistrarUsuario(string cedula,string contrasenia) {
            ConexionBD con = new ConexionBD();
            con.RegistroUsuario(cedula,contrasenia,1);
        }

        public void RegistrarEstudiante(string cedula, string Nombre, string Apellido1, string Apellido2
            , string Nacionalidad, string Correo, string telefono, DateTime FechaNac, int IDCarrera) {
            ConexionBD con = new ConexionBD();
            con.RegistroEstudiante(cedula, Nombre, Apellido1, Apellido2, Nacionalidad, Correo, telefono, FechaNac, IDCarrera);
        }


    }
}
